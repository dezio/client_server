// (C) 2013 - Dennis Ziolkowski
// Server : MessagePacket.cs

#region Usings

using System;

#endregion

namespace DeZio.Networking.Packet {
    public class MessagePacket {
        public MessagePacket() {}

        public String Message { get; set; }
        public String Type { get; set; }
        public Session Session { get; set; }

        public static MessagePacket GetInitPacket() {
            var requestSessionPacket = new MessagePacket
                {
                    Type = "Init",
                    Message = ""
                };
            return requestSessionPacket;
        }

        public static MessagePacket GetOkPacket(String type = "") {
            var requestSessionPacket = new MessagePacket
                {
                    Type = type,
                    Message = "Ok"
                };
            return requestSessionPacket;
        }

        public static MessagePacket GetFailPacket() {
            var requestSessionPacket = new MessagePacket
                {
                    Type = "Failed",
                    Message = ""
                };
            return requestSessionPacket;
        }

        public override string ToString() {
            return Xml.ConvertToString(this);
        }

        public static MessagePacket PacketFromString(String xml) {
            return Xml.ConvertToXml<MessagePacket>(xml);
        }
    }
}