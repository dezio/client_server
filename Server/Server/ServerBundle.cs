// (C) 2013 - Dennis Ziolkowski
// Server : ServerBundle.cs

namespace Server {
    internal class ServerBundle {
        private readonly MessageServer _messageServer = new MessageServer();
        private readonly SessionServer _sessionServer = new SessionServer();

        public ServerBundle() {}

        public void StartBundle() {
            _sessionServer.Start();
            _messageServer.Start();
        }

        public void StopBundle() {
            _sessionServer.Stop();
            _messageServer.Stop();
        }
    }
}