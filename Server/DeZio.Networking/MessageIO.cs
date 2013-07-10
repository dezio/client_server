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
    public class MessageIO {
        private bool m_bStarted = false;
        private bool m_bUseCrypto = false;

        public MessageIO(NetworkStream stream, String contextName) {
            Stream = stream;
            Context = contextName;
        }

        private String Context { get; set; }
        protected NetworkStream Stream { get; set; }
        private Session CurrentSession { get; set; }
        public event EventHandler PacketArrived;

        public void SetSession(Session currentSession) {
            CurrentSession = currentSession;
        }

        public void Start() {
            if (!m_bStarted) {
                m_bStarted = true;
                Task.Run(() => ReadLoop());
            } // if end
            else {
                throw new Exception("Already started.");
            } // else end
        }

        public void Stop() {
            m_bStarted = false;
            Stream.Close();
        }

        private void ReadLoop() {
            while (m_bStarted) {
                Console.WriteLine(string.Format("MessageIO[{0}]: Waiting for input.", Context));
                try {
                    var reader = new StreamReader(Stream);
                    String strLine;
                    var sbRawSessInf = new StringBuilder();
                    while ((strLine = reader.ReadLine()) != null && m_bStarted) {
                        sbRawSessInf.AppendLine(strLine);
                        var typeOfPacket = typeof (MessagePacket).Name;
                        if (strLine.Trim().EndsWith(String.Format("</{0}>", typeOfPacket))) {
                            break;
                        } // if end
                    } // while end
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
                catch (Exception ex) {
                    
                    return;
                }
            } // while end
        }

        public void WritePacket(MessagePacket p, bool bWithEncKey = false) {
            Thread.Sleep(50);
            p.Session = CurrentSession;
            String strUnencrypted = p.Message;
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

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(string.Format("MessageIO[{0}] >>>:", Context));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", sbSafePacket);
            ConsoleExtension.PrintHorizontalLine();
            var streamWriter = new StreamWriter(Stream);
            streamWriter.WriteLine(sbSafePacket);
            streamWriter.Flush();
        }
    }
}