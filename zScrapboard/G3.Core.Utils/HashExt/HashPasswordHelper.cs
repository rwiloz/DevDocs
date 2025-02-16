using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace G3.Core.Utils.HashExt
{
    public static class HashPasswordHelper
    {
        public static string HashPassWord(this string password)
        {
            if (password == null || password.Length < 6)
            {
                //throw new Exception("Invalid password to hash");
                return null;
            }

            var salt = BitConverter.GetBytes(password.Length * password.Length);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        //used for G2Oss migrated users
        //get key from Sentinel.ClientSystem, saltGuid is the user Id
        public static string HashPasswordSentinel(this string password, Guid saltGuid, string key)
        {
            return SentinelCryptography.SentinelPasswordHash(saltGuid, password, key);
        }
    }

    internal class SentinelEncryptionRequest
    {
        public byte[] Value { get; set; }
        /// <summary>
        /// Initial vector for the encryption algorithm.
        /// </summary>
        public byte[] IV { get; set; }
        /// <summary>
        /// Encryption key for the encryption algorithm.
        /// </summary>
        public byte[] Key { get; set; }
    }
    
    internal static class SentinelCryptography
    {
        private static byte[] AdjustByteArray(byte[] value, int newSize)
        {
            var oldSize = value.Length;
            if (newSize == oldSize) return value;
            var result = new byte[newSize];
            if (newSize > oldSize)
            {
                for (int i = 0; i < newSize; i++)
                    result[i] = value[i % oldSize];
            }
            else if (newSize < oldSize)
            {
                for (int i = 0; i < oldSize; i++)
                    result[i % newSize] ^= value[i];
            }

            return result;
        }

        private static byte[] GenerateIV(byte[] salt = null)
        {
            using var symAlgo = Aes.Create();
            symAlgo.GenerateIV();
            if (salt == null) return symAlgo.IV;
            else
            {
                var hash = SentinelHash(salt);
                return AdjustByteArray(hash, symAlgo.IV.Length);
            }
        }


        private static byte[] Encrypt(SentinelEncryptionRequest request)
        {
            using var symAlgo = Aes.Create();
            symAlgo.Key = request.Key;
            symAlgo.IV = request.IV ?? symAlgo.IV;
            symAlgo.Padding = PaddingMode.PKCS7;

            var data = request.Value;

            using var ms = new MemoryStream();
            ms.Write(symAlgo.IV, 0, symAlgo.IV.Length);
            using var cs = new CryptoStream(ms, symAlgo.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();
            return ms.ToArray();
        }

        private static byte[] SentinelHash(byte[] request)
        {
            using (var sha = SHA256.Create())
            {
                return sha.ComputeHash(request);
            }

            ;
        }

        private static byte[] CreatePasswordHash(Guid Id, string password, string key)
        {
            // generate initial vector based on user's id
            var iv = GenerateIV(Id.ToByteArray());

            // encrypt on client system's password
            var data = Encrypt(new SentinelEncryptionRequest
            {
                Key = Convert.FromBase64String(key),
                IV = iv,
                Value = Encoding.UTF8.GetBytes(password)
            });

            // hash result 
            data = SentinelHash(data);

            return data;
        }

        public static string SentinelPasswordHash(Guid id, string password, string key)
        {
            var hash = CreatePasswordHash(id, password, key);
            return Convert.ToBase64String(hash);

        }
    }

}
