using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace G3.Core.Utils.HashExt
{
    public static class HashHelper
    {
        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static string G3HashSha256Utf8(this string data)
        {
            using var sha256Hash = SHA256.Create();
            return G3Hash(Encoding.UTF8.GetBytes(data));
        }

        public static string G3HashSha256Utf32(this string data)
        {
            using var sha256Hash = SHA256.Create();
            return G3Hash(Encoding.UTF32.GetBytes(data));
        }

        public static string Sha384IntegrityHash(this string rawData)
        {
            return Sha384IntegrityHash(Encoding.UTF8.GetBytes(rawData));
        }

        public static string Sha384IntegrityHash(this byte[] rawData)
        {
            using var sha384Hash = SHA384.Create();
            var bytes = sha384Hash.ComputeHash(rawData);
            return $"sha384-{Convert.ToBase64String(bytes)}";
        }

        public static string G3Hash(this byte[] data)
        {
            using var sha256Hash = SHA256.Create();
            var bytes = sha256Hash.ComputeHash(data);
            return ByteArrayToHexString(bytes);
        }
    }
}
