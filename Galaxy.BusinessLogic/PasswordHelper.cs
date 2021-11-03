using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.BusinessLogic
{
    public static class PasswordHelper
    {
        public static string HashString(this string str)
        {
            SHA256 sha = SHA256.Create();
            var bytes = Encoding.UTF32.GetBytes(str);
            var hashBytes = sha.ComputeHash(bytes);

            var sBuilder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sBuilder.Append(hashBytes[i].ToString("x2"));
            }
            string hexString = sBuilder.ToString();

            return hexString;
        }

//        public static bool CompareHashes(this string str, string hashHex)
//        {
//            SHA256 sha = SHA256.Create();
//            var bytes = Encoding.UTF32.GetBytes(str);
//            var hashBytes = sha.ComputeHash(bytes);

//            var sBuilder = new StringBuilder();
//            for (int i = 0; i < hashBytes.Length; i++)
//            {
//                sBuilder.Append(hashBytes[i].ToString("x2"));
//            }
//            string hexString = sBuilder.ToString();
//.
//            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

//            return comparer.Compare(hexString, hashHex) == 0;
//        }
    }
}
