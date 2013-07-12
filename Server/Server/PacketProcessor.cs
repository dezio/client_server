// (C) 2013 - Dennis Ziolkowski
// Server : PacketProcessor.cs

#region Usings

using System;
using System.Collections.Generic;
using DeZio.Networking.Packet;

#endregion

namespace Server {
    public abstract class PacketProcessor {
        protected PacketProcessor(MessagePacket p) {
            Requirements = new Dictionary<string, object>();
        }

        public Dictionary<String, Object> Requirements { get; set; }

        public abstract void Do();
    }
}