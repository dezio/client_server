// (C) 2013 - Dennis Ziolkowski
// Server : Client.cs

#region Usings

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Client.Events;
using DeZio.Networking;
using DeZio.Networking.Packet;

#endregion

namespace Client {
    public class ClientInstance : IDisposable {
        private const int InitSessionPort = 44801;

        private TcpClient m_clientMessageServer;

        public ClientInstance() {
            MessagePort = 0;
        }

        private NetworkStream Stream { get; set; }
        public ContactInfo ContactInfo { get; set; }
        private MessageIO IO { get; set; }
        private Session CurrentSession { get; set; }
        public bool LoggedIn { get; private set; }
        public int MessagePort { get; private set; }
        private bool WaitAuthResult { get; set; }

        /// <summary>
        ///     Gets the current session id
        /// </summary>
        public String SessionId {
            get { return CurrentSession.SessionId; }
        }

        public void Dispose() {
            Stream.Dispose();
            GC.SuppressFinalize(this);
        }

        public event EventHandler GotPacket;
        public event EventHandler GotLoggedIn;
        public event EventHandler<Events.GotContactInfoEventArgs> GotMyInfo;
        public event EventHandler<Events.GotContactInfoEventArgs> GotContactInfo;
        public event EventHandler<Events.GotChatMessageEventArgs> GotChatMessage;

        private void ReaderOnPacketArrived(object sender, EventArgs eventArgs) {
            var packet = (sender as MessagePacket);
            if (packet != null && GotPacket != null)
                GotPacket(packet, null);
            if (packet != null && packet.Type == "Contact") {
                if (GotContactInfo != null) {
                    GotContactInfo(this, new GotContactInfoEventArgs(ContactInfo.FromQuery(packet.Message)));
                } // if end
            } // if end
            if (packet != null && packet.Type == "YourInfo") {
                var myContInfo = ContactInfo.FromQuery(packet.Message);
                if (GotMyInfo != null) {
                    GotMyInfo(null, new GotContactInfoEventArgs(myContInfo));
                } // if end
                this.ContactInfo = myContInfo;
                Console.WriteLine(string.Format("Got my data: {0}", myContInfo.Username));
            } // if end
            if (packet != null && packet.Type == "Message") {
                var q = HttpUtility.ParseQueryString(packet.Message);
                if (GotChatMessage != null) {
                    var contact = new ContactInfo()
                        {
                            UserId = int.Parse(q["from"]),
                            Username = "Unknown"
                        };

                    GotChatMessage(this, new GotChatMessageEventArgs()
                        {
                            From = contact,
                            Message = q["msg"]
                        });
                } // if end
            } // if end
            if (packet != null && packet.Type == "Login") {
                if (packet.Message == "Ok") {
                    LoggedIn = true;
                    if (GotLoggedIn != null) {
                        GotLoggedIn(this, null);
                    }
                } // if end
                else {
                    throw new AuthenticationException();
                }
                Console.WriteLine("Got my data: {0}", packet.Message);
            } // if end
        }

        public void WritePacket(MessagePacket p) {
            IO.WritePacket(p);
        }

        public void Authenticate(String username, String pw = "") {
            if (MessagePort < 0) {
                throw new Exception("You are not connected to the server.");
            } // if end

            WritePacket(new MessagePacket()
                {
                    Message = string.Format("username={0}&pw={1}", username, pw),
                    Type = "Login"
                });
        }

        public void LogInToMessageServer() {
            m_clientMessageServer = new TcpClient();
            m_clientMessageServer.Connect("127.0.0.1", MessagePort);
            Stream = new NetworkStream(m_clientMessageServer.Client);
            IO = new MessageIO(m_clientMessageServer.GetStream(), "Client");
            IO.SetSession(CurrentSession);
            IO.PacketArrived += ReaderOnPacketArrived;
            IO.Start();
            IO.WritePacket(new MessagePacket(), true);
            Console.WriteLine("Connected to messageServer at {0}",
                            (m_clientMessageServer.Client.RemoteEndPoint as IPEndPoint));
        }

        public void InitSession() {
            var clt = new TcpClient();
            clt.Connect("127.0.0.1", InitSessionPort);
            var networkStream = clt.GetStream();
            var btPacket = Encoding.Default.GetBytes(MessagePacket.GetInitPacket() + Environment.NewLine);
            networkStream.Write(btPacket, 0, btPacket.Length);
            networkStream.Flush();
            var reader = new StreamReader(networkStream);
            String strLine;
            var sbRawSessInf = new StringBuilder();
            while ((strLine = reader.ReadLine()) != null) {
                sbRawSessInf.AppendLine(strLine);
            } // while end
            var packetSessionInfo = MessagePacket.PacketFromString(sbRawSessInf.ToString());
            clt.Close();
            var messageQuery = HttpUtility.ParseQueryString(packetSessionInfo.Message);
            var sid = messageQuery["sid"];
            var encKey = messageQuery["enckey"];
            var msgPort = messageQuery["port"];
            CurrentSession = new Session
                {
                    EncryptKey = encKey,
                    SessionId = sid
                };

            MessagePort = int.Parse(msgPort);
        }

        public void Dispose(bool f) {
            
            GC.SuppressFinalize(this);
        }
    }
}