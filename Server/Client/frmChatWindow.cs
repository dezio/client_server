using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controls;
using DeZio.Networking;
using mshtml;

namespace Client {
    public partial class frmChatWindow : Form {
        public ContactInfo Remote { get; set; }
        ManualResetEvent m_resetWaitLoaded = new ManualResetEvent(false);
        private delegate void onNewMessage(String msg);
        private ClientModel Client {
            get; set; }

        public frmChatWindow(ContactInfo remote, ClientModel clt) {
            this.Remote = remote;
            this.Client = clt;
            InitializeComponent();
            pnlChat.HorizontalScroll.Enabled = false;
            pnlChat.HorizontalScroll.Visible = false;
            pnlChat.VerticalScroll.Enabled = true;
            pnlChat.VerticalScroll.Visible = true;
        }

        public void NewMessage(String msg) {
            if (this.InvokeRequired) {
                m_resetWaitLoaded.WaitOne(1000);
                Invoke(new onNewMessage(NewMessage), msg);
                return;
            } // if end
            
            var msgView = new Controls.ChatMessageView(ChatMessageView.MessageDirection.Incoming, msg, Remote.Username, DateTime.Now)
                {
                    Width = pnlChat.Width,
                    Location = new Point(0, pnlChat.Controls.Count*40)
                };

            pnlChat.Controls.Add(msgView);
        }

        private void webChatHistory_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if(e.Url.OriginalString.Contains("about:b"))
                m_resetWaitLoaded.Set();
        }

        private void frmChatWindow_Shown(object sender, EventArgs e) {
        }

        private void webChatHistory_Navigated(object sender, WebBrowserNavigatedEventArgs e) {

        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
        }

        private void txtChatOut_MouseDown(object sender, MouseEventArgs e) {
            
        }

        private void txtChatOut_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.Handled = true;
                bttnSend_Click(txtChatOut, EventArgs.Empty);
            } // if end
        }

        private void bttnSend_Click(object sender, EventArgs e) {
            var textBox = sender as TextBox;
            if (textBox != null) Client.SendMessage(textBox.Text, Remote.UserId);
            txtChatOut.Text = "";
        }
    }
}
