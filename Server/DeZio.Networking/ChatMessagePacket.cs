// (C) 2013 - Dennis Ziolkowski
// Server : ChatMessagePacket.cs

#region Usings

using System;
using DeZio.Networking.Packet;

#endregion

namespace DeZio.Networking {
    public class ChatMessagePacket {
        public ChatMessagePacket() {}
        public String Message { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public MessagePacket Packet {
            get {
                return new MessagePacket()
                    {
                        Type = "Message",
                        Message = string.Format("from={0}&to={1}&msg={2}",
                                                FromUserId, ToUserId, Message)
                    };
            }
        }
    }
}