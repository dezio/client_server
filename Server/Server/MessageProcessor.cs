// (C) 2013 - Dennis Ziolkowski
// Server : MessageProcessor.cs

using System.Web;
using DeZio.Networking;
using DeZio.Networking.Packet;

namespace Server {
    public class MessageProcessor {
        private static MessageProcessor _Instance;

        private MessageProcessor() {}

        public static MessageProcessor Instance {
            get { return _Instance ?? (_Instance = new MessageProcessor()); }
        }

        public void IncomingMessage(MessagePacket pack) {
            var messageInfo = HttpUtility.ParseQueryString(pack.Message);
            var toUserId = messageInfo["to"];
            var fromUserId = messageInfo["from"];
            var msgText = messageInfo["msg"];
            var client = MessageServer.Clients.Find(c => c.Contact.UserId == int.Parse(toUserId));
            if (int.Parse(toUserId) == -1)
            {
                var packErrorMsg = new ChatMessagePacket
                    {
                        ToUserId = int.Parse(fromUserId),
                        Message = "You can't send a message to the server."
                    };
                client.IO.WritePacket(packErrorMsg.Packet);
            } // if end

            if (client.CurrentSession != null) {
                var msgPacket = new MessagePacket()
                    {
                        Type = "Message",
                        Message = string.Format("from={0}&to={1}&msg={2}",
                        fromUserId, toUserId, msgText)
                    };
                client.IO.WritePacket(msgPacket);
            } // if end
        }
    }
}