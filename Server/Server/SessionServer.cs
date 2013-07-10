// (C) 2013 - Dennis Ziolkowski
// Server : SessionServer.cs

#region Usings

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using DeZio.Networking;
using DeZio.Networking.Packet;

#endregion

namespace Server {
    public class SessionServer : ServerBase {
        public SessionServer() {
            ClientSessions = new List<Session>();
            Listener = new TcpListener(IPAddress.Any, 44801);
        }

        private List<Session> ClientSessions { get; set; }

        protected override void AcceptClient(TcpClient clt) {
            Thread.Sleep(199);
            var netStream = clt.GetStream();
            var sbPacket = new StringBuilder();
            using (var reader = new StreamReader(netStream)) {
                var strLine = "";
                while ((strLine = reader.ReadLine()) != null) {
                    sbPacket.AppendLine(strLine);
                    if (strLine.Contains("\0") || strLine.Trim().EndsWith("</MessagePacket>"))
                        break;
                } // while end

                var pack = MessagePacket.PacketFromString(sbPacket.ToString());
                Console.WriteLine(pack.Message);
                SendSessionInformation(
                    Session.GenerateNewSession(),
                    (netStream)
                    );

                netStream.Close();
            } // using end
        }

        private static void SendSessionInformation(Session sess, Stream stream) {
            var sessMessage = String.Format("sid={0}&enckey={1}&port=44802", sess.SessionId, sess.EncryptKey);
            var requestSessionPacket = new MessagePacket
                {
                    Type = "NewSession",
                    Message = sessMessage
                };

            var btPacket = Encoding.Default.GetBytes(Xml.ConvertToString(requestSessionPacket) + Environment.NewLine);
            stream.Write(btPacket, 0, btPacket.Length);
            stream.Flush();
            stream.Close();
        }
    }
}