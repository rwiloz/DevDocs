//using System;
//using System.IO;
//using System.Security.Cryptography;
//using System.Text;

//namespace G3.Core.Utils.Encryptions
//{
//    /// 
//    /// Summary description for converter
//    /// 
//    //http://www.dotnetspider.com/resources/5096-Encryption-decryption-sample.aspx
//    public static class RijndaelUtility
//    {
//        public static string Decrypt(string textToBeDecrypted, string password, string salt = null)
//        {
//            using var rijndaelCipher = new RijndaelManaged();
//            string decryptedData;

//            try
//            {
//                var encryptedData = Convert.FromBase64String(textToBeDecrypted);

//                if (salt == null)
//                    salt = password.Length.ToString();

//                var saltBytes = Encoding.ASCII.GetBytes(salt);

//                //Making of the key for decryption
//                var secretKey = new PasswordDeriveBytes(password, saltBytes);

//                //Creates a symmetric Rijndael decryptor object.
//                using var decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
//                using var memoryStream = new MemoryStream(encryptedData);
//                using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

//                var plainText = new byte[encryptedData.Length];
//                var count = cryptoStream.Read(plainText, 0, plainText.Length);
//                var decryptedCount = count;

//                while (cryptoStream.CanRead && count>0)
//                {
//                    count = cryptoStream.Read(plainText, decryptedCount, plainText.Length - decryptedCount);
//                    decryptedCount += count;
//                }

//                //Converting to string
//                decryptedData = Encoding.Unicode.GetString(plainText, 0, decryptedCount);
//            }
//            catch
//            {
//                decryptedData = textToBeDecrypted;
//            }
//            return decryptedData;
//        }

//        public static string Encrypt(string textToBeEncrypted, string password, string salt = null)
//        {
//            using var rijndaelCipher = new RijndaelManaged();
//            var plainText = System.Text.Encoding.Unicode.GetBytes(textToBeEncrypted);

//            if (salt == null)
//                salt = password.Length.ToString();

//            var saltBytes = Encoding.ASCII.GetBytes(salt);

//            //Making of the key for decryption
//            var secretKey = new PasswordDeriveBytes(password, saltBytes);

//            //Creates a symmetric encryptor object. 
//            using var encryptor = rijndaelCipher.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
//            using var memoryStream = new MemoryStream();
//            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

//            cryptoStream.Write(plainText, 0, plainText.Length);
//            //Writes the final state and clears the buffer
//            cryptoStream.FlushFinalBlock();

//            var cipherBytes = memoryStream.ToArray();
//            var encryptedData = Convert.ToBase64String(cipherBytes);
//            return encryptedData;
//        }
//    }
//}
