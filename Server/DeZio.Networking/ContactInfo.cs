// (C) 2013 - Dennis Ziolkowski
// Server : ContactInfo.cs

#region Usings

using System;
using System.Drawing;
using System.Web;

#endregion

namespace DeZio.Networking {
    public class ContactInfo {
        public int UserId { get; set; }

        public String Username { get; set; }
        public ContactState State { get; set; }
        public Image Image { get; set; }

        public static ContactInfo FromQuery(String queryString) {
            var q = HttpUtility.ParseQueryString(queryString);
            var contactInfo = new ContactInfo {
                State = (ContactState)int.Parse(q["state"]),
                UserId = int.Parse(q["userId"]),
                Username = q["username"]
            };
            return contactInfo;
        }
    }
}