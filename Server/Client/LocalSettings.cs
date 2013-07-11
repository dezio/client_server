using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Client {
    class LocalSettings {
        private const String SubKey = @"Software\DeZio\CryptoChatClient";
        public static void Set(String key, String value) {
            Registry.CurrentUser.CreateSubKey(SubKey);
            using (var regKey = Registry.CurrentUser.OpenSubKey(SubKey)) {
                regKey.SetValue(key, value);
            } // using end
        }

        public static String Get(String key) {
            Registry.CurrentUser.CreateSubKey(SubKey);
            using (var regKey = Registry.CurrentUser.OpenSubKey(SubKey)) {
                if (regKey != null) {
                    var result = regKey.GetValue(key);
                    if (result == null)
                        return null;
                    return result.ToString();
                } // if end
                else
                    return null;
            } // using end
        }
    }
}
