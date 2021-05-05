using System;
using System.Security.Cryptography;
using System.Text;

namespace ControlCenter.Client.Sequrity
{
    public static class Cryptography
    {
        public static string Sign(string data, string key)
        {
            var encoding = new UTF8Encoding();
            var keyBytes = encoding.GetBytes(key);
            var dataBytes = encoding.GetBytes(data);
            using var hmacsha1 = new HMACSHA1(keyBytes);

            var hashData = hmacsha1.ComputeHash(dataBytes);
            return Convert.ToBase64String(hashData);
        }

        public static string GetPasswordHash(string password)
        {
            var encoding = new UTF8Encoding();
            var keyBytes = encoding.GetBytes(Keys.PasswordHashingKey);
            var dataBytes = encoding.GetBytes(password);
            using var hmacsha1 = new HMACSHA1(keyBytes);

            var hashData = hmacsha1.ComputeHash(dataBytes);
            return Convert.ToBase64String(hashData);
        }
    }
}
