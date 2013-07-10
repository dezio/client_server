// (C) 2013 - Dennis Ziolkowski
// Server : GotChatMessageEventArgs.cs

#region Usings

using System;
using DeZio.Networking;

#endregion

namespace Client.Events {
    public class GotChatMessageEventArgs : EventArgs {
        public ContactInfo From { get; set; }
        public String Message { get; set; }

        public GotChatMessageEventArgs() {
            
        }
    }
}