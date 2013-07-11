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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChatWindow));
            this.txtChatOut = new System.Windows.Forms.TextBox();
            this.bttnSend = new System.Windows.Forms.Button();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pnlChat = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtChatOut
            // 
            this.txtChatOut.AcceptsReturn = true;
            this.txtChatOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChatOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChatOut.Location = new System.Drawing.Point(12, 310);
            this.txtChatOut.Multiline = true;
            this.txtChatOut.Name = "txtChatOut";
            this.txtChatOut.Size = new System.Drawing.Size(452, 46);
            this.txtChatOut.TabIndex = 1;
            this.txtChatOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChatOut_KeyDown);
            this.txtChatOut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChatOut_KeyUp);
            this.txtChatOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtChatOut_MouseDown);
            // 
            // bttnSend
            // 
            this.bttnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnSend.Location = new System.Drawing.Point(470, 310);
            this.bttnSend.Name = "bttnSend";
            this.bttnSend.Size = new System.Drawing.Size(132, 46);
            this.bttnSend.TabIndex = 2;
            this.bttnSend.Text = "&Send";
            this.bttnSend.UseVisualStyleBackColor = true;
            this.bttnSend.Click += new System.EventHandler(this.bttnSend_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(614, 25);
            this.toolStripMain.TabIndex = 3;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // pnlChat
            // 
            this.pnlChat.AutoScroll = true;
            this.pnlChat.BackColor = System.Drawing.Color.White;
            this.pnlChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChat.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlChat.Location = new System.Drawing.Point(12, 28);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(590, 276);
            this.pnlChat.TabIndex = 4;
            this.pnlChat.WrapContents = false;
            this.pnlChat.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlChat_ControlAdded);
            this.pnlChat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlChat_MouseDown);
            this.pnlChat.MouseEnter += new System.EventHandler(this.pnlChat_MouseEnter);
            // 
            // frmChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 368);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.bttnSend);
            this.Controls.Add(this.txtChatOut);
            this.KeyPreview = true;
            this.Name = "frmChatWindow";
            this.Text = "Chat with <unknown>";
            this.Shown += new System.EventHandler(this.frmChatWindow_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChatWindow_KeyDown);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChatOut;
        private System.Windows.Forms.Button bttnSend;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.FlowLayoutPanel pnlChat;

    }
}