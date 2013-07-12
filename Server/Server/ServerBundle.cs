// (C) 2013 - Dennis Ziolkowski
// Server : ServerBundle.cs

namespace Server {
    internal class ServerBundle {
        private MessageServer _messageServer = new MessageServer();
        private SessionServer _sessionServer = new SessionServer();

        public ServerBundle() {}

        public MessageServer MessageServer {
            get { return _messageServer; }
            set { _messageServer = value; }
        }

        public SessionServer SessionServer {
            get { return _sessionServer; }
            set { _sessionServer = value; }
        }

        public void StartBundle() {
            SessionServer.Start();
            MessageServer.Start();
        }

        public void StopBundle() {
            SessionServer.Stop();
            MessageServer.Stop();
        }
    }
}