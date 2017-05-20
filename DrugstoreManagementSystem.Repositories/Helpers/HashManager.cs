using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagementSystem.Repositories
{
    public static class HashManager
    {
        public static string GetHash(string text)
        {
            using (var sha1 = new SHA1Managed())
            {
                var hashBytes = sha1.ComputeHash(Encoding.Unicode.GetBytes(text));                                
                var resultHash = new StringBuilder(hashBytes.Length * 2);
                foreach (var hashByte in hashBytes)
                {
                    resultHash.AppendFormat("{0:x2}", hashByte);
                }
                return resultHash.ToString();
            }
        }
    }
}
