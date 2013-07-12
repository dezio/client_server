namespace Client {
    partial class frmChatWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtChatOut = new System.Windows.Forms.TextBox();
            this.bttnSend = new System.Windows.Forms.Button();
            this.pnlChat = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtChatOut
            // 
            this.txtChatOut.AcceptsReturn = true;
            this.txtChatOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChatOut.BackColor = System.Drawing.Color.Green;
            this.txtChatOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChatOut.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatOut.ForeColor = System.Drawing.Color.White;
            this.txtChatOut.Location = new System.Drawing.Point(3, 16);
            this.txtChatOut.Multiline = true;
            this.txtChatOut.Name = "txtChatOut";
            this.txtChatOut.Size = new System.Drawing.Size(554, 55);
            this.txtChatOut.TabIndex = 1;
            this.txtChatOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChatOut_KeyDown);
            this.txtChatOut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChatOut_KeyUp);
            this.txtChatOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtChatOut_MouseDown);
            // 
            // bttnSend
            // 
            this.bttnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnSend.Location = new System.Drawing.Point(563, 16);
            this.bttnSend.Name = "bttnSend";
            this.bttnSend.Size = new System.Drawing.Size(75, 55);
            this.bttnSend.TabIndex = 2;
            this.bttnSend.Text = "&Send";
            this.bttnSend.UseVisualStyleBackColor = true;
            this.bttnSend.Click += new System.EventHandler(this.bttnSend_Click);
            // 
            // pnlChat
            // 
            this.pnlChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChat.AutoScroll = true;
            this.pnlChat.BackColor = System.Drawing.Color.Transparent;
            this.pnlChat.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlChat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlChat.Location = new System.Drawing.Point(3, 16);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(641, 233);
            this.pnlChat.TabIndex = 4;
            this.pnlChat.WrapContents = false;
            this.pnlChat.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlChat_ControlAdded);
            this.pnlChat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlChat_MouseDown);
            this.pnlChat.MouseEnter += new System.EventHandler(this.pnlChat_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pnlChat);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 340);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Green;
            this.panel2.Controls.Add(this.txtChatOut);
            this.panel2.Controls.Add(this.bttnSend);
            this.panel2.Location = new System.Drawing.Point(6, 255);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 74);
            this.panel2.TabIndex = 5;
            // 
            // frmChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.ClientSize = new System.Drawing.Size(671, 364);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmChatWindow";
            this.Text = "Chat with <unknown>";
            this.Shown += new System.EventHandler(this.frmChatWindow_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChatWindow_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtChatOut;
        private System.Windows.Forms.Button bttnSend;
        private System.Windows.Forms.FlowLayoutPanel pnlChat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

    }
}