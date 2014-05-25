using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EOS.utility {
    class SecurityHelper {
        public static string hash(string data) {
            SHA256Managed crypt = new SHA256Managed();
            string result = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(data), 0, Encoding.ASCII.GetByteCount(data));

            foreach (byte bit in crypto) {
                result += bit.ToString("x2");
            }

            return result;
        }

    }
}
