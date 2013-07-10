// (C) 2013 - Dennis Ziolkowski
// Server : GotContactInfoEventArgs.cs

#region Usings

using System;
using DeZio.Networking;

#endregion

namespace Client.Events {
    public class GotContactInfoEventArgs : EventArgs {
        public GotContactInfoEventArgs(ContactInfo contactInfo) {
            Contact = contactInfo;
        }

        public ContactInfo Contact { get; set; }
    }
}