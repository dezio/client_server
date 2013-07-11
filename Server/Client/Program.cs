// (C) 2013 - Dennis Ziolkowski
// Server : Program.cs

#region Usings

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Client {
    internal static class Program {
        private static ClientInstance _client;

        public static ClientInstance Client {
            get { return _client ?? (_client = new ClientInstance()); }
        }

        /// <summary>
        ///     Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main() {
            Task.Factory.StartNew(delegate {
                Client.InitSession();
                Client.LogInToMessageServer();
                Thread.Sleep(500);
            });
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var dlgLogin = new frmLogin();
            dlgLogin.ShowDialog();
            if (Client.LoggedIn != false) {
                Application.Run(new frmMain());
            } // if end
        }
    }
}