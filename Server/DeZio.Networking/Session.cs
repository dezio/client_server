// (C) 2013 - Dennis Ziolkowski
// Server : Session.cs

#region Usings

using System;

#endregion

namespace DeZio.Networking {
    public class Session {
        public Session() {}
        public String SessionId { get; set; }
        public String EncryptKey { get; set; }

        public static Session GenerateNewSession() {
            var sess = new Session
                {
                    EncryptKey = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16),
                    SessionId = Guid.NewGuid().ToString()
                };
            return sess;
        }
    }
}