// (C) 2013 - Dennis Ziolkowski
// Server : MessageServer.cs

#region Usings

using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

#endregion

namespace Server {
    public class MessageServer : ServerBase {
        public static List<ClientProcessor> Clients { get; set; }

        public MessageServer() {
            Listener = new TcpListener(IPAddress.Any, 44802);
            Listener.Start();
            Clients = new List<ClientProcessor>();
        }

        protected override void AcceptClient(TcpClient clt) {
            Task.Run(() => {
                var cltProc = new ClientProcessor(clt);
                Clients.Add(cltProc);
            });
        }
    }
}