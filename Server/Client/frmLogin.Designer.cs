namespace Client {
    partial class frmLogin {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.bttnLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.picLoadingAnim = new System.Windows.Forms.PictureBox();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.pnlLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadingAnim)).BeginInit();
            this.SuspendLayout();
            // 
            // bttnLogin
            // 
            this.bttnLogin.Location = new System.Drawing.Point(295, 144);
            this.bttnLogin.Name = "bttnLogin";
            this.bttnLogin.Size = new System.Drawing.Size(75, 23);
            this.bttnLogin.TabIndex = 0;
            this.bttnLogin.Text = "&Anmelden";
            this.bttnLogin.UseVisualStyleBackColor = true;
            this.bttnLogin.Click += new System.EventHandler(this.bttnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(42, 43);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(302, 22);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(42, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(302, 22);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(42, 24);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(81, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Benutzername";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(42, 83);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Passwort";
            // 
            // pnlLoading
            // 
            this.pnlLoading.Controls.Add(this.lblPleaseWait);
            this.pnlLoading.Controls.Add(this.picLoadingAnim);
            this.pnlLoading.Location = new System.Drawing.Point(12, 12);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(358, 159);
            this.pnlLoading.TabIndex = 5;
            this.pnlLoading.Visible = false;
            // 
            // picLoadingAnim
            // 
            this.picLoadingAnim.Image = global::Client.Properties.Resources._22_1;
            this.picLoadingAnim.Location = new System.Drawing.Point(77, 54);
            this.picLoadingAnim.Name = "picLoadingAnim";
            this.picLoadingAnim.Size = new System.Drawing.Size(34, 34);
            this.picLoadingAnim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoadingAnim.TabIndex = 0;
            this.picLoadingAnim.TabStop = false;
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.Location = new System.Drawing.Point(116, 54);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(126, 30);
            this.lblPleaseWait.TabIndex = 1;
            this.lblPleaseWait.Text = "Bitte warten...";
            this.lblPleaseWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.bttnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(382, 179);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.bttnLogin);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anmelden";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            this.pnlLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoadingAnim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlLoading;
        private System.Windows.Forms.Label lblPleaseWait;
        private System.Windows.Forms.PictureBox picLoadingAnim;
    }
}

