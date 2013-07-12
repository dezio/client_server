namespace Client {
    partial class frmSearchContact {
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearchField = new System.Windows.Forms.Label();
            this.txtSearchCondition = new System.Windows.Forms.TextBox();
            this.bttnSearch = new System.Windows.Forms.Button();
            this.treeResults = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.DarkGreen;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(546, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Find a contact";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSearchField
            // 
            this.lblSearchField.Location = new System.Drawing.Point(1, 46);
            this.lblSearchField.Name = "lblSearchField";
            this.lblSearchField.Size = new System.Drawing.Size(82, 20);
            this.lblSearchField.TabIndex = 1;
            this.lblSearchField.Text = "Search:";
            this.lblSearchField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchCondition
            // 
            this.txtSearchCondition.Location = new System.Drawing.Point(89, 47);
            this.txtSearchCondition.Name = "txtSearchCondition";
            this.txtSearchCondition.Size = new System.Drawing.Size(364, 22);
            this.txtSearchCondition.TabIndex = 2;
            // 
            // bttnSearch
            // 
            this.bttnSearch.Location = new System.Drawing.Point(459, 46);
            this.bttnSearch.Name = "bttnSearch";
            this.bttnSearch.Size = new System.Drawing.Size(75, 23);
            this.bttnSearch.TabIndex = 3;
            this.bttnSearch.Text = "&Search";
            this.bttnSearch.UseVisualStyleBackColor = true;
            this.bttnSearch.Click += new System.EventHandler(this.bttnSearch_Click);
            // 
            // treeResults
            // 
            this.treeResults.Location = new System.Drawing.Point(4, 75);
            this.treeResults.Name = "treeResults";
            this.treeResults.Size = new System.Drawing.Size(530, 203);
            this.treeResults.TabIndex = 4;
            // 
            // frmSearchContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(546, 290);
            this.Controls.Add(this.treeResults);
            this.Controls.Add(this.bttnSearch);
            this.Controls.Add(this.txtSearchCondition);
            this.Controls.Add(this.lblSearchField);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmSearchContact";
            this.Text = "frmSearchContact";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchContact_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearchField;
        private System.Windows.Forms.TextBox txtSearchCondition;
        private System.Windows.Forms.Button bttnSearch;
        private System.Windows.Forms.TreeView treeResults;
    }
}