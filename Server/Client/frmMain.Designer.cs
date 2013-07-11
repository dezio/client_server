namespace Client {
    partial class frmMain {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.treeContacts = new System.Windows.Forms.TreeView();
            this.imageListContactState = new System.Windows.Forms.ImageList(this.components);
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.toolStripItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.abmeldenUndBeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeContacts
            // 
            this.treeContacts.FullRowSelect = true;
            this.treeContacts.ImageIndex = 2;
            this.treeContacts.ImageList = this.imageListContactState;
            this.treeContacts.ItemHeight = 24;
            this.treeContacts.Location = new System.Drawing.Point(12, 52);
            this.treeContacts.Name = "treeContacts";
            this.treeContacts.SelectedImageIndex = 2;
            this.treeContacts.ShowLines = false;
            this.treeContacts.ShowPlusMinus = false;
            this.treeContacts.ShowRootLines = false;
            this.treeContacts.Size = new System.Drawing.Size(354, 466);
            this.treeContacts.TabIndex = 0;
            // 
            // imageListContactState
            // 
            this.imageListContactState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListContactState.ImageStream")));
            this.imageListContactState.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListContactState.Images.SetKeyName(0, "Status-tray-busy-icon[1].png");
            this.imageListContactState.Images.SetKeyName(1, "Status-tray-online-icon[1].png");
            this.imageListContactState.Images.SetKeyName(2, "Status-tray-offline-icon[1].png");
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripItemFile});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(378, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // toolStripItemFile
            // 
            this.toolStripItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abmeldenUndBeendenToolStripMenuItem});
            this.toolStripItemFile.Name = "toolStripItemFile";
            this.toolStripItemFile.Size = new System.Drawing.Size(46, 20);
            this.toolStripItemFile.Text = "&Datei";
            // 
            // abmeldenUndBeendenToolStripMenuItem
            // 
            this.abmeldenUndBeendenToolStripMenuItem.Name = "abmeldenUndBeendenToolStripMenuItem";
            this.abmeldenUndBeendenToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.abmeldenUndBeendenToolStripMenuItem.Text = "Abmelden und &Beenden";
            this.abmeldenUndBeendenToolStripMenuItem.Click += new System.EventHandler(this.abmeldenUndBeendenToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 530);
            this.Controls.Add(this.treeContacts);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeContacts;
        private System.Windows.Forms.ImageList imageListContactState;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripItemFile;
        private System.Windows.Forms.ToolStripMenuItem abmeldenUndBeendenToolStripMenuItem;
    }
}