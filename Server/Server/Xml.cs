// (C) 2013 - Dennis Ziolkowski
// Server : Xml.cs

#region Usings

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

#endregion

namespace Server {
    internal class Xml {
        public static String ConvertToString<T>(T tObject) {
            var serializer = new XmlSerializer(typeof (T));
            using (var stream = new MemoryStream()) {
                serializer.Serialize(stream, tObject);
                return Encoding.Default.GetString(stream.GetBuffer());
            } // using end
        }

        public static T ConvertToXml<T>(string xml) {
            xml = xml.Trim();
            xml = xml.Replace("\0", "");
            var lines = xml.Split('\n').ToList();
            var lastLine = lines.Last().Trim();
            if (xml.EndsWith(Environment.NewLine)) {
                xml = "";
                for (var index = 0; index < lines.Count - 1; index++) {
                    string str = lines[index];
                    xml += str.Trim();
                    xml += index < lines.Count - 2 ? Environment.NewLine : "";
                } // for end
            } // if end
            var serializer = new XmlSerializer(typeof (T));
            return (T) serializer.Deserialize(new StringReader(xml));
        }
    }
}