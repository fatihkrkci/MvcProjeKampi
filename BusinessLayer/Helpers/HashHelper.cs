using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BusinessLayer.Helpers
{
    public static class HashHelper
    {
        public static string ComputeHash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyHash(string input, string hashedValue)
        {
            string inputHash = ComputeHash(input);
            return inputHash == hashedValue;
        }
    }
}