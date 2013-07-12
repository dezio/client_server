// (C) 2013 - Dennis Ziolkowski
// Server : ClientModel.cs

#region Usings

using System;
using System.Collections.Generic;
using System.Threading;
using Client.Events;
using DeZio.Networking;

#endregion

namespace Client {
    public class ClientModel {
        private readonly ManualResetEvent m_objWaitLogin = new ManualResetEvent(false);

        public ClientModel() {
            Contacts = new List<ContactInfo>();
            Program.Client.GotPacket += ClientOnGotPacket;
            Program.Client.GotContactInfo += ClientOnGotContactInfo;
            Program.Client.GotLoggedIn += ClientOnGotLoggedIn;
            Program.Client.GotMyInfo += ClientOnGotMyInfo;
            Program.Client.GotChatMessage += ClientOnGotChatMessage;
        }

        private List<ContactInfo> Contacts { get; set; }

        public ContactInfo MyContactInfo {
            get { return Program.Client.ContactInfo; }
        }

        private void ClientOnGotChatMessage(object sender, GotChatMessageEventArgs gotChatMessageEventArgs) {
            if (GotChatMessage != null) {
                gotChatMessageEventArgs.From = Contacts.Find(c => c.UserId == gotChatMessageEventArgs.From.UserId);
                GotChatMessage(this, gotChatMessageEventArgs);
            }
        }

        private void ClientOnGotContactInfo(object sender, GotContactInfoEventArgs gotContactInfoEventArgs) {
            if (GotContactInfo != null) {
                GotContactInfo(this, new GotContactInfoEventArgs(gotContactInfoEventArgs.Contact));
                var findContact = Contacts.FindAll(c => c.UserId == gotContactInfoEventArgs.Contact.UserId);
                if (findContact.Count == 0) {
                    Contacts.Add(gotContactInfoEventArgs.Contact);
                } // if end
                else {
                    for (int i = 0; i < Contacts.Count - 1; i++) {
                        if (Contacts[i].UserId == gotContactInfoEventArgs.Contact.UserId) {
                            Contacts[i] = gotContactInfoEventArgs.Contact;
                        } // if end
                    } // for end
                } // else end
            } // if end
        }

        private void ClientOnGotMyInfo(object sender, GotContactInfoEventArgs gotContactInfoEventArgs) {
            if (GotMyInfo != null) {
                GotMyInfo(this, new GotContactInfoEventArgs(gotContactInfoEventArgs.Contact));
            } // if end
        }

        private void ClientOnGotLoggedIn(object sender, EventArgs eventArgs) {
            m_objWaitLogin.Set();
        }

        public void SendMessage(String strMessage, int toUserId) {
            if (!String.IsNullOrEmpty(strMessage.Trim())) {
                var obj = new ChatMessagePacket
                    {
                        FromUserId = MyContactInfo.UserId,
                        ToUserId = toUserId,
                        Message = strMessage
                    };
                Program.Client.WritePacket(obj.Packet);
            } // if end
        }

        public event EventHandler<GotContactInfoEventArgs> GotContactInfo;
        public event EventHandler<GotContactInfoEventArgs> GotMyInfo;
        public event EventHandler<GotChatMessageEventArgs> GotChatMessage;

        private void ClientOnGotPacket(object sender, EventArgs eventArgs) {}

        public bool Authenticate(String strUsername, String strPassword) {
            Program.Client.Authenticate(strUsername, strPassword);
            return m_objWaitLogin.WaitOne(1500);
        }
    }
}