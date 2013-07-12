using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using DeZio.Networking.Packet;

namespace Client {
    public partial class frmSearchContact : Form {
        private delegate void onAddSearchResult(String res);
        public frmSearchContact() {
            InitializeComponent();
            Program.Client.GotPacket += ClientOnGotPacket;
        }

        private void ClientOnGotPacket(object sender, EventArgs eventArgs) {
            var packet = (sender as MessagePacket);
            if (packet != null && packet.Type == "SearchResult") {
                var result = HttpUtility.ParseQueryString(packet.Message);
                int resultCount = int.Parse(result["count"]);
                for (int i = 0; i < resultCount; i++) {
                    var userInfo = result[String.Format("result[{0}]", i)];
                    this.Invoke(new onAddSearchResult(AddSearchResult), userInfo);
                }
            } // if end
        }

        private void AddSearchResult(String result) {
            var tn = new TreeNode(result);
            treeResults.Nodes.Add(tn);
        }

        private void DoSearch() {
            treeResults.Nodes.Clear();
            var packet = new MessagePacket
                {
                    Message = txtSearchCondition.Text, 
                    Type = "SearchContact"
                };
            
            Program.Client.WritePacket(packet);
        }

        private void bttnSearch_Click(object sender, EventArgs e) {
            DoSearch();
        }

        private void frmSearchContact_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Hide();
        }
    }
}
