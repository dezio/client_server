using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeZio.Networking.Packet;

namespace Server.Processors.Packet {
    public class SearchContact : PacketProcessor {
        public SearchContact(MessagePacket p) : base(p) {
            Requirements.Add("packet", p);
        }

        private List<String> GetResultByString(String search) {
            var foundUsernames = new List<string>();
            using (var helper = new DatabaseHelper()) {
                var sql = String.Format("SELECT * FROM tblUsers WHERE username LIKE '%{0}%' OR mailAddress LIKE '%{0}%'",
                                  search);
                var reader = helper.Reader(sql);
                while (reader.Read()) {
                    var userIdOfResult = reader.GetString(reader.GetOrdinal("userId"));
                    var clientProcessor = Requirements["client"] as ClientProcessor;
                    if (clientProcessor != null && int.Parse(userIdOfResult) == clientProcessor.Contact.UserId) {
                        continue;
                    } // if end
                    foundUsernames.Add(reader.GetString(reader.GetOrdinal("username")));
                } // while end
            } // using end
            return foundUsernames;
        }

        public override void Do() {
            var packet = (Requirements["packet"] as MessagePacket);
            var client = (Requirements["client"] as ClientProcessor);
            if (packet != null) {
                var strSearchPhrase = packet.Message;
                var result = GetResultByString(strSearchPhrase);
                var stringBuilder = new StringBuilder();
                for (int index = 0; index < result.Count; index++) {
                    var aResult = result[index];
                    stringBuilder.AppendFormat("&result[{1}]={0}", aResult, index);
                } // for end
                stringBuilder.AppendFormat("&count={0}", result.Count);
                var packetReturn = new MessagePacket {
                    Type = "SearchResult",
                    Message = stringBuilder.ToString()
                };
                if (client != null)
                    client.IO.WritePacket(packetReturn);
            } // if end
        }
    }
}
