// (C) 2013 - Dennis Ziolkowski
// Server : ServerBase.cs

#region Usings

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Server {
    public abstract class ServerBase {
        protected TcpListener Listener { get; set; }
        private Thread ThreadListenerLoop { get; set; }
        private Boolean Started { get; set; }

        public void Start() {
            Listener.Start();
            Started = true;
            ThreadListenerLoop = new Thread(ListenerLoop);
            ThreadListenerLoop.Start();
        }

        public void Stop() {
            Started = false;
            Thread.Sleep(50);
            ThreadListenerLoop.Abort();
            var ipEndPoint = Listener.LocalEndpoint as IPEndPoint;
            if (ipEndPoint != null)
                Console.WriteLine("Listener loop at port {0} closed", ipEndPoint.Port);
        }

        private void ListenerLoop() {
            var ipEndPoint = Listener.LocalEndpoint as IPEndPoint;
            if (ipEndPoint != null)
                Console.WriteLine("Listener loop started at port {0}", ipEndPoint.Port);
            while (Started) {
                if (Listener.Pending()) {
                    var client = Listener.AcceptTcpClient();
                    Task.Run(() => AcceptClient(client));
                    Console.WriteLine("New client attached.");
                } // if end
                Thread.Sleep(10);
            } // while end
        }

        protected abstract void AcceptClient(TcpClient clt);
    }
}