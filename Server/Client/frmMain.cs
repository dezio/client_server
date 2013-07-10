// (C) 2013 - Dennis Ziolkowski
// Server : frmMain.cs

#region Usings

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Client.Events;
using DeZio.Networking;

#endregion

namespace Client {
    public partial class frmMain : Form {
        private delegate void onNewMessage(GotChatMessageEventArgs ea);
        public frmMain() {
            InitializeComponent();
            ChatWindows = new List<frmChatWindow>();
            Client = new ClientModel();
            Client.GotContactInfo += ClientOnGotContactInfo;
            Client.GotMyInfo += ClientOnGotMyInfo;
            Client.GotChatMessage += ClientOnGotChatMessage;
        }

        private void ClientOnGotChatMessage(object sender, GotChatMessageEventArgs gotChatMessageEventArgs) {
            this.Invoke(new onNewMessage(NewMessage), gotChatMessageEventArgs);
        }

        private void NewMessage(GotChatMessageEventArgs ea) {
            var chatWin = ChatWindows.Find(win => win.Remote.UserId == ea.From.UserId);
            if (chatWin == null) {
                chatWin = new frmChatWindow(ea.From, this.Client);
                ChatWindows.Add(chatWin);
            } // if end
            chatWin.Show();
            chatWin.NewMessage(ea.Message);
        }

        private void ClientOnGotMyInfo(object sender, GotContactInfoEventArgs gotContactInfoEventArgs) {
            ProcessMyInfo(gotContactInfoEventArgs.Contact);
        }

        private List<frmChatWindow> ChatWindows { get; set; } 
        private ClientModel Client { get; set; }

        private void ProcessMyInfo(ContactInfo info) {
            if (this.InvokeRequired) {
                this.Invoke(new _contactInfoMethod(ProcessMyInfo), info);
                return;
            } // if end
            this.Text = string.Format("Logged in as {0}", info.Username);
        }

        private void AddContact(ContactInfo info) {
            if (this.InvokeRequired) {
                this.Invoke(new _contactInfoMethod(AddContact), info);
                return;
            } // if end
            var n = new TreeNode
                {
                    Text = info.Username, 
                    Tag = info
                };
            switch (info.State) {
                case(ContactState.Offline):
                    n.ImageIndex = 0;
                    break;
                case (ContactState.Online):
                    n.ImageIndex = 1;
                    break;
            } // switch end
            treeContacts.Nodes.Add(info.Username);
        }

        private void ClientOnGotContactInfo(object sender, GotContactInfoEventArgs gotContactInfoEventArgs) {
            AddContact(gotContactInfoEventArgs.Contact);
        }

        private delegate void _contactInfoMethod(ContactInfo info);

        private void abmeldenUndBeendenToolStripMenuItem_Click(object sender, EventArgs e) {
            Program.Client.Dispose();
            Application.Exit();
        }
    }
}