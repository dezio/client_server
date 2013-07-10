// (C) 2013 - Dennis Ziolkowski
// Server : frmLogin.cs

#region Usings

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Client {
    public partial class frmLogin : Form {
        private bool m_bLoginLocked = false;
        public frmLogin() {
            InitializeComponent();
            Client = new ClientModel();
        }

        private ClientModel Client { get; set; }

        private void HideLoading() {
            if (this.InvokeRequired) {
                this.Invoke(new MethodInvoker(HideLoading));
                return;
            } // if end
            pnlLoading.Visible = m_bLoginLocked = false;
        }

        private void ShowLoading() {
            if (this.InvokeRequired) {
                this.Invoke(new MethodInvoker(ShowLoading));
                return;
            } // if end
            pnlLoading.Visible = m_bLoginLocked = true;
        }

        private void bttnLogin_Click(object sender, EventArgs e) {
            Task.Run(() => {
                if (m_bLoginLocked)
                    return;
                ShowLoading();
                var bSuccess = Client.Authenticate(txtUsername.Text, txtPassword.Text);
                if (!bSuccess) {
                    MessageBox.Show("Die eingegebenen Daten sind falsch.", "AuthenticationException",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    HideLoading();
                } // if end
                else {
                    Invoke(new MethodInvoker(Close));
                } // else end
                
            });
        }

        private void frmLogin_Shown(object sender, EventArgs e) {
            this.txtUsername.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e) {

        }
    }
}