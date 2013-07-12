// (C) 2013 - Dennis Ziolkowski
// Server : MessageProcessor.cs

using System.Diagnostics;
using System.Reflection;
using System.Threading;
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
            var clientToSendTo = MessageServer.Clients.Find(c => c.Contact.UserId == int.Parse(toUserId));
            if (int.Parse(toUserId) == -1) {
                var commandReturningMessage = "";
                if (msgText.StartsWith("/")) {
                    commandReturningMessage = "Can't recognize your command.";
                    if (msgText.Contains("/about")) {
                        commandReturningMessage = string.Format("Server Version {0}\n" +
                                                                "{1} registered clients.\n",
                                                                ApplicationInfo.Version,
                                                                MessageServer.Clients.Count);
                    } // if end
                    if (msgText.Contains("/logout")) {
                        commandReturningMessage = string.Format("You will be logged out.");
                        MessageServer.Clients.Find(c => c.Contact.UserId == int.Parse(fromUserId)).IO.Stop();
                    } // if end
                }
                else {
                    commandReturningMessage = "The value is not an command.";
                } // else end
                var packErrorMsg = new ChatMessagePacket {
                    ToUserId = int.Parse(fromUserId),
                    FromUserId = -1,
                    Message = commandReturningMessage
                };
                clientToSendTo = MessageServer.Clients.Find(c => c.Contact.UserId == int.Parse(fromUserId));
                clientToSendTo.IO.WritePacket(packErrorMsg.Packet);
            } // if end
            else if (int.Parse(toUserId) > 0 && clientToSendTo.CurrentSession != null) {
                var msgPacket = new MessagePacket()
                    {
                        Type = "Message",
                        Message = string.Format("from={0}&to={1}&msg={2}",
                        fromUserId, toUserId, msgText)
                    };
                clientToSendTo.IO.WritePacket(msgPacket);
            } // if end 
        }
    }
}