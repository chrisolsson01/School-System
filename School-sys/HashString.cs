using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace School_sys
{

    /*
     * -------------------------------
     * Author: Liam Lillieroth
     * -------------------------------
     * Class HashString:
     * Take string input from schoolsys_login and schoolsys_admin
     * hash that string and return hashed value.
     * -------------------------------
     */
    class HashString
    {
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
