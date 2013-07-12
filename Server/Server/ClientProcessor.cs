// (C) 2013 - Dennis Ziolkowski
// Server : ClientProcessor.cs

#region Usings

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;
using DeZio.Networking;
using DeZio.Networking.Packet;
using Server.Processors.Packet;

#endregion

namespace Server {
    public class ClientProcessor {

        public ClientProcessor(TcpClient clt) {
            Client = clt;
            Stream = new NetworkStream(clt.Client);
            IO = new MessageIO(Stream, "Server");
            IO.PacketArrived += ReaderOnPacketArrived;
            IO.Start();
            ReadInitMessage();
        }

        public MessageIO IO { get; set; }
        public TcpClient Client { get; private set; }
        public Session CurrentSession { get; private set; }
        public Version RemoteAppVersion {
            get; private set; }
        public ContactInfo Contact {
            get; set; }
        private NetworkStream Stream { get; set; }

        private void ReaderOnPacketArrived(object sender, EventArgs eventArgs) {
            var packet = (sender as MessagePacket);
            ProcessPacket(packet);
        }

        private void ReadInitMessage() {
            var sbPacket = new StringBuilder();
            var reader = new StreamReader(Stream);
            String strLine;
            var btBuffer = new byte[2048];
            Stream.Read(btBuffer, 0, btBuffer.Length);
            sbPacket.Append(Encoding.Default.GetString(btBuffer));
            var pack = MessagePacket.PacketFromString(sbPacket.ToString());
            CurrentSession = pack.Session;
            IO.SetSession(CurrentSession);

            Console.WriteLine(String.Format("A client (SID: {0}) is now connected to the message server.",
                                          CurrentSession.SessionId));
        }

        private void SendContactsList() {
            var rand = new Random();
            var userServerPacket = new MessagePacket {
                Type = "Contact",
                Message = String.Format(
                    "username={0}&state={1}&userid={2}",
                    string.Format("Server"),
                    ((int)ContactState.NonExist),
                    -1)
            };
            Thread.Sleep(40);
            IO.WritePacket(userServerPacket);
            for (var i = 0; i < 10; i++) {
                var userPacket = new MessagePacket {
                    Type = "Contact",
                    Message = String.Format(
                        "username={0}&state={1}&userid={2}",
                        string.Format("User_Testservice_{0}", rand.Next(100, 200+i)), 
                        ((int)ContactState.Offline), 
                        -1)
                };
                Thread.Sleep(40);
                IO.WritePacket(userPacket);
            } // for end
        }

        private void ProcessPacket(MessagePacket p) {
            if (p == null) {
                return;
            } // if end
            if (p.Session.SessionId != CurrentSession.SessionId) {
                return;
            } // if end
            if (p.Type == "Message") {
                MessageProcessor.Instance.IncomingMessage(p);
            } // if end
            if (p.Type == "SearchContact") {
                var proc = new SearchContact(p);
                proc.Requirements.Add("client", this);
                proc.Do();
            } // if end
            if (p.Type == "AddContact") {
                
            } // if end
            if (p.Type == "Login") {
                if (p.Session.SessionId == CurrentSession.SessionId) {
                    var msgQuery = HttpUtility.ParseQueryString(p.Message);
                    var username = msgQuery["username"];
                    var pw = Crypto.GetMd5Hash(msgQuery["pw"]);
                    var appVersion = msgQuery["appVersion"];
                    RemoteAppVersion = new Version(appVersion);
                    using (var dbHelper = new DatabaseHelper()) {
                        var userInfo = dbHelper.Authenticate(username, pw);
                        if (userInfo.State != ContactState.NonExist) {
                            Console.WriteLine(username + @" tries to log in.");
                            IO.WritePacket(MessagePacket.GetOkPacket("Login"));
                            var userPacket = new MessagePacket
                                {
                                    Type = "YourInfo",
                                    Message = String.Format(
                                        "username={0}&state={1}&userid={2}",
                                        userInfo.Username, ((int) userInfo.State), userInfo.UserId)
                                };
                            Contact = ContactInfo.FromQuery(userPacket.Message);
                            IO.WritePacket(userPacket);
                            SendContactsList();
                            var msgPacketDummy = new MessagePacket() {
                                Type = "Message",
                                Message = string.Format("from={0}&to={1}&msg={2}",
                                "-1", Contact.UserId, string.Format("Welcome. " +
                                                                    "You are online as {0} with the user ID {1}." +
                                                                    "\nYour current sessionId is: {2}" +
                                                                    "\nYour appVersion is {3}", Contact.Username, Contact.UserId, CurrentSession.SessionId, RemoteAppVersion))
                            };
                            MessageProcessor.Instance.IncomingMessage(msgPacketDummy);
                        } // if end
                        else {
                            IO.WritePacket(MessagePacket.GetFailPacket());
                        } // else end
                    }
                } // if end
            } // if end
        }
    }
}