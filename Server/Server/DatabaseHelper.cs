// (C) 2013 - Dennis Ziolkowski
// Server : DatabaseHelper.cs

#region Usings

using System;
using DeZio.Networking;
using MySql.Data.MySqlClient;

#endregion

namespace Server {
    internal class DatabaseHelper : IDisposable {
        private readonly MySqlConnection db;

        public DatabaseHelper() {
            db = new MySqlConnection("SERVER=localhost;DATABASE=dbChat;UID=root;PASSWORD=;");
            db.Open();
        }

        public void Dispose() {
            db.Dispose();
        }

        public ContactInfo Authenticate(String username, String pwMd5) {
            var contactInfo = new ContactInfo
                {
                    State = ContactState.NonExist
                };

            String strSql =
                String.Format("SELECT * FROM tblUsers " +
                              "WHERE username='{0}' AND password='{1}'", username, pwMd5);
            var objSqlResult = Reader(strSql);
            bool bFound = false;
            while (objSqlResult.Read()) {
                contactInfo.UserId = objSqlResult.GetInt32(objSqlResult.GetOrdinal("userId"));
                contactInfo.Username = objSqlResult.GetString(objSqlResult.GetOrdinal("username"));
                contactInfo.State = ContactState.Online;
                bFound = true;
            }
            return contactInfo;
        }

        private MySqlDataReader Reader(String strSql) {
            using (var cmd = db.CreateCommand()) {
                cmd.CommandText = strSql;
                return cmd.ExecuteReader();
            } // using end
        }
    }
}