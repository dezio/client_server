// (C) 2013 - Dennis Ziolkowski
// Server : MessageIO.cs

#region Usings

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DeZio.Networking.Packet;

#endregion

namespace DeZio.Networking {
    public class MessageIO : IDisposable {
        private bool m_bStarted = false;
        private bool m_bUseCrypto = true;
        private Task m_taskReader;
        public event EventHandler OnDisconnection;

        /// <summary>
        /// Initializes a new MessageIO object.
        /// </summary>
        /// <param name="stream">The networkstream to Read/Write</param>
        /// <param name="contextName">A name for this reader <example>e.g. Client or Server</example></param>
        public MessageIO(NetworkStream stream, String contextName) {
            Stream = stream;
            Context = contextName;
        }

        ~MessageIO() {
            this.Dispose();
        }

        private String Context { get; set; }
        protected NetworkStream Stream { get; set; }
        private Session CurrentSession { get; set; }
        /// <summary>
        /// Will be raised when a packet was arrived.
        /// </summary>
        public event EventHandler PacketArrived;

        /// <summary>
        /// Sets the session.
        /// </summary>
        /// <param name="currentSession">The session.</param>
        public void SetSession(Session currentSession) {
            CurrentSession = currentSession;
        }

        /// <summary>
        /// Starts the reader.
        /// </summary>
        public void Start() {
            if (!m_bStarted) {
                m_bStarted = true;
                m_taskReader = Task.Run(() => ReadLoop());
            } // if end
            else {
                throw new Exception("Already started.");
            } // else end
        }

        /// <summary> 
        /// Stops the reader and closes the stream.
        /// </summary>
        public void Stop() {
            m_bStarted = false;
            Stream.Close();
        }

        /// <summary>
        /// Reads the stream in a loop and raises <see cref="PacketArrived">PacketArrived</see>
        /// when a packet arrived.
        /// </summary>
        private void ReadLoop() {
            var reader = new StreamReader(Stream);
            while (m_bStarted) {
                try {
                    Console.WriteLine(string.Format("MessageIO[{0}]: Waiting for input.", Context));
                    String strLine;
                    var sbRawSessInf = new StringBuilder();
                    if (reader.EndOfStream) {
                        Console.WriteLine("An user was disconnected.");
                        if (OnDisconnection != null) {
                            OnDisconnection(this, null);
                        } // if end
                        return;
                    } // if end
                    while ((strLine = reader.ReadLine()) != null && m_bStarted) {
                        sbRawSessInf.AppendLine(strLine);
                        var typeOfPacket = typeof (MessagePacket).Name;
                        if (strLine.Trim().EndsWith(String.Format("</{0}>", typeOfPacket))) {
                            break;
                        } // if end
                    } // while end
                    if (strLine == null)
                        continue;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(string.Format("MessageIO[{0}] <<<: ", Context));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}", sbRawSessInf);
                    ConsoleExtension.PrintHorizontalLine();
                    var pack = MessagePacket.PacketFromString(sbRawSessInf.ToString());
                    if (m_bUseCrypto) {
                        pack.Message = Crypto.DecryptStringAES(pack.Message, CurrentSession.EncryptKey);
                        pack.Type = Crypto.DecryptStringAES(pack.Type, CurrentSession.EncryptKey);
                    } // if end
                    if (PacketArrived != null)
                        PacketArrived(pack, null);
                }
                catch (System.IO.IOException) {
                    Console.WriteLine("An user was disconnected.");

                    return;
                } // catch end
            } // while end
        }

        private void onDisconnected() {
            if (OnDisconnection != null) {
                OnDisconnection(this, null);
            } // if end
        }

        /// <summary>
        /// Writes a packet to the stream.
        /// </summary>
        /// <param name="p">The packet to write.</param>
        /// <param name="bWithEncKey">Determines whether the encryption is used.</param>
        public void WritePacket(MessagePacket p, bool bWithEncKey = false) {
            Thread.Sleep(50);
            if (m_taskReader.IsCanceled) {
                if (OnDisconnection != null) {
                    OnDisconnection(this, null);
                } // if end
                return;
            } // if end
            p.Session = CurrentSession;
            if (!String.IsNullOrEmpty(p.Message) && m_bUseCrypto) {
                p.Message = Crypto.EncryptStringAES(p.Message, CurrentSession.EncryptKey);
                p.Type = Crypto.EncryptStringAES(p.Type, CurrentSession.EncryptKey);
            } // if end
            var sbSafePacket = new StringBuilder();
            var packet = p.ToString();
            // packet = Regex.Replace(packet, "\b\r\n", "");
            foreach (String strLine in packet.Split('\n')) {
                if (strLine.Contains("EncryptKey") && !bWithEncKey) {
                    continue;
                } // if end
                sbSafePacket.AppendLine(strLine.TrimEnd());
            } // if end

            
            if (Stream.CanWrite) {
                try {
                    var streamWriter = new StreamWriter(Stream);
                    streamWriter.WriteLine(sbSafePacket);
                    streamWriter.Flush();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(string.Format("MessageIO[{0}] >>>:", Context));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}", sbSafePacket);
                    ConsoleExtension.PrintHorizontalLine();
                }
                catch (IOException) {
                    onDisconnected();
                }
            } // if end
        }

        /// <summary>
        /// Disposes this object.
        /// </summary>
        public void Dispose() {
            this.Stream.Close();
        }
    }
}