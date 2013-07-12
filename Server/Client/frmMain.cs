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
        private frmSearchContact m_frmSearchContact = new frmSearchContact();
        public frmMain() {
            InitializeComponent();
            ChatWindows = new List<frmChatWindow>();
            Client = new ClientModel();
            Client.GotContactInfo += ClientOnGotContactInfo;
            Client.GotMyInfo += ClientOnGotMyInfo;
            Client.GotChatMessage += ClientOnGotChatMessage;
        }

        private List<frmChatWindow> ChatWindows { get; set; }
        private ClientModel Client { get; set; }

        private void ClientOnGotChatMessage(object sender, GotChatMessageEventArgs gotChatMessageEventArgs) {
            this.Invoke(new onNewMessage(NewMessage), gotChatMessageEventArgs);
        }

        private void NewMessage(GotChatMessageEventArgs ea) {
            OpenChatWindow(ea.From).NewMessage(ea.Message);
        }

        private frmChatWindow OpenChatWindow(ContactInfo info) {
            ChatWindows.RemoveAll(frm => frm.IsDisposed);
            var chatWin = ChatWindows.Find(win => win.Remote.UserId == info.UserId);
            if (chatWin == null) {
                chatWin = new frmChatWindow(info, this.Client);
                ChatWindows.Add(chatWin);
            } // if end
            chatWin.Show();
            return chatWin;
        }

        private void ClientOnGotMyInfo(object sender, GotContactInfoEventArgs gotContactInfoEventArgs) {
            ProcessMyInfo(gotContactInfoEventArgs.Contact);
        }

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
                case (ContactState.Offline):
                    n.ImageIndex = 0;
                    break;
                case (ContactState.Online):
                    n.ImageIndex = 1;
                    break;
            } // switch end

            treeContacts.Nodes.Add(n);
        }

        private void ClientOnGotContactInfo(object sender, GotContactInfoEventArgs gotContactInfoEventArgs) {
            AddContact(gotContactInfoEventArgs.Contact);
        }

        private void abmeldenUndBeendenToolStripMenuItem_Click(object sender, EventArgs e) {
            Program.Client.Dispose();
            Application.Exit();
        }

        private void treeContacts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            var contact = e.Node.Tag as ContactInfo;
            OpenChatWindow(contact);
        }

        private delegate void _contactInfoMethod(ContactInfo info);

        private delegate void onNewMessage(GotChatMessageEventArgs ea);

        private void suchenToolStripMenuItem_Click(object sender, EventArgs e) {
            m_frmSearchContact.Show();
        }
    }
}