using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;

namespace G3.Core.Utils.Encryptions
{
    /// 
    /// Summary description for converter
    /// 
    //http://www.dotnetspider.com/resources/5096-Encryption-decryption-sample.aspx
    public static class AesUtility
    {
        //using UTF8 is more efficient
        public static string DecryptAes(this string textToBeDecrypted, string password, string salt = null,
            bool utf8 = false)
        {
            using var aes = Aes.Create();
            string decryptedData;

            try
            {
                var encryptedData = Convert.FromBase64String(textToBeDecrypted);

                salt ??= password.Length.ToString();

                var saltBytes = Encoding.ASCII.GetBytes(salt);

                //Making of the key for decryption
                var secretKey = new PasswordDeriveBytes(password, saltBytes);

                //Creates a symmetric Rijndael decryptor object.
                using var decryptor = aes.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
                using var memoryStream = new MemoryStream(encryptedData);
                using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                var bytes = new byte[encryptedData.Length];
                var count = cryptoStream.Read(bytes, 0, bytes.Length);
                var decryptedCount = count;

                while (cryptoStream.CanRead && count > 0)
                {
                    count = cryptoStream.Read(bytes, decryptedCount, bytes.Length - decryptedCount);
                    decryptedCount += count;
                }

                //Converting to string
                decryptedData = utf8
                    ? Encoding.UTF8.GetString(bytes, 0, decryptedCount)
                    : Encoding.Unicode.GetString(bytes, 0, decryptedCount);
            }
            catch //(Exception ex)
            {
                decryptedData = textToBeDecrypted;
            }

            return decryptedData;
        }

        public static string DecryptAesUtf8(this string textToBeDecrypted, string password, string salt = null)
        {
            return DecryptAes(textToBeDecrypted, password, salt, true);
        }


        public static string EncryptAes(this string textToBeEncrypted, string password, string salt = null,
            bool utf8 = false)
        {
            using var aes = Aes.Create();

            var bytes = utf8
                ? Encoding.UTF8.GetBytes(textToBeEncrypted)
                : Encoding.Unicode.GetBytes(textToBeEncrypted);

            salt ??= password.Length.ToString();

            var saltBytes = Encoding.ASCII.GetBytes(salt);

            //Making of the key for decryption
            var secretKey = new PasswordDeriveBytes(password, saltBytes);

            //Creates a symmetric encryptor object. 
            using var encryptor = aes.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(bytes, 0, bytes.Length);
            //Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();

            var cipherBytes = memoryStream.ToArray();
            var encryptedData = Convert.ToBase64String(cipherBytes);
            return encryptedData;
        }

        //todo migrate to newer
        public static string EncryptAesUtf8(this string textToBeEncrypted, string password, string salt = null)
        {
            return EncryptAes(textToBeEncrypted, password, salt, true);
        }

        public static string EncryptAes(this string plainText, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();

            var encryptor = aes.CreateEncryptor(key, iv);

            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);

            using var sw = new StreamWriter(cs);
            sw.Write(plainText);
            //flush
            sw.Dispose();

            var encrypted = ms.ToArray();

            //cs.Dispose();
            //ms.Dispose();

            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptAes(this string cipherText, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();

            var decryptor = aes.CreateDecryptor(key, iv);
            var cipherTextBytes = Convert.FromBase64String(cipherText);

            using var ms = new MemoryStream(cipherTextBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cs);

            var plainText = reader.ReadToEnd();
            reader.Dispose();
            //cs.Dispose();
            //ms.Dispose();

            return plainText;
        }

        /*password
         Looking at https://github.com/kmaragon/Konscious.Security.Cryptography with Argon2id
        https://gist.github.com/sixpeteunder/235f93ba0b059035abf140beb2ea4e44

        public class PasswordService : IPasswordService
{
    public byte[] CreateHash(byte[] password, byte[] salt)
    {
        using var argon2 = new Argon2id(password);
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = 8;
        argon2.Iterations = 4;
        argon2.MemorySize = 1024 * 128;


        also from main project
        argon2.DegreeOfParallelism = 16;
        argon2.MemorySize = 8192;
        argon2.Iterations = 40;
        argon2.Salt = salt;
        argon2.AssociatedData = userUuidBytes;

        return argon2.GetBytes(32);                
    }
        
    public bool VerifyHash(byte[] password, byte[] salt, byte[] hash) => 
        HashPassword(password, salt).SequenceEqual(hash);

    public static byte[] GenerateSalt()
    {
        var buffer = new byte[32];
        using var rng = new RNGCryptoServiceProvider();
        rng.GetBytes(buffer);
        return buffer;
    }
}


        
// Creating
var bytes = Encoding.UTF8.GetBytes("password");
var salt = PasswordService.GenerateSalt(); // Salt should be stored alongside hash.
var hash = passwordService.CreateHash(bytes, salt);

// Verifying
if(passwordService.VerifyHash(bytes, salt, hash))
{
         */
    }
}
