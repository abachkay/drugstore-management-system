using System.Security.Cryptography;
using System.Text;

namespace DrugstoreManagementSystem.Common
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