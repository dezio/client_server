// (C) 2013 - Dennis Ziolkowski
// Server : Session.cs

#region Usings

using System;

#endregion

namespace DeZio.Networking {
    /// <summary>
    /// Represents a session.
    /// </summary>
    public class Session {
        public Session() {}
        /// <summary>
        /// Gets or sets the current session Id.
        /// </summary>
        public String SessionId { get; set; }
        /// <summary>
        /// Gets or sets the encryption key.
        /// </summary>
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