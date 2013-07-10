using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeZio.Networking.Packet;

namespace DeZio.Networking {
    public class ChatMessagePacket {

        public String Message {
            get; set; }

        public int FromUserId {
            get; set; }

        public int ToUserId {
            get;
            set;
        }

        public MessagePacket Packet {
            get {
                return new MessagePacket() {
                    Type = "Message",
                    Message = string.Format("from={0}&to={1}&msg={2}",
                    FromUserId, ToUserId, Message)
                };
            }
        }

        public ChatMessagePacket() {
            
        }
    }
}
