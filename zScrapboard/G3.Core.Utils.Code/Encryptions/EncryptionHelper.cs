Sure. Here are XML summary comments for your code: 

```csharp
using G3.Core.Utils.Strings;
using System;
using System.Text;

/// <summary>
/// Namespace that contains utility classes for encryption purposes.
/// </summary>
namespace G3.Core.Utils.Encryptions
{
    /// <summary>
	/// Provides utilities to handle encryption tasks.
	/// </summary>
    public static class EncryptionHelper
    {

        private static CryptoRandom random;
        private static readonly object LockObj = new();

        /// <summary>
        /// Generates a random character.
        /// </summary>
        private static char RandomChar()
        {
            lock (LockObj)
            {
                if (random == null)
                    random = new CryptoRandom();

                return (char)random.Next(32, 126);
            }
        }

        /// <summary>
        /// Generate a random number up to the specified max value.
        /// </summary>
        public static int RandomNumber(int max)
        {
            lock (LockObj)
            {
                if (random == null)
                    random = new CryptoRandom();

                return random.Next(max);
            }
        }

        /// <summary>
        /// Generate a random number within the specified range.
        /// </summary>
        public static int RandomNumber(int min, int max)
        {
            lock (LockObj)
            {
                if (random == null)
                    random = new CryptoRandom();

                return random.Next(min, max);
            }
        }

        /// <summary>
        /// Decodes a base64-encoded password.
        /// </summary>
        public static string DecodePassword(this string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                password = password.Base64Decode().DecodeText();
            }

            return password;
        }

        /// <summary>
        /// Encodes a password into base64 format.
        /// </summary>
        public static string EncodePassword(this string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                password = password.EncodeText().Base64Encode();
            }

            return password;
        }

        [Obsolete("Migrate to KeyManaged Encrypted (Enc) system settings")]
        public static string EncryptPassword(this string data, string key)
        {
            if (key.IsNullOrEmpty()) return data;
            return FillData(data).EncryptAes(key);
        }

        [Obsolete("Migrate to KeyManaged Encrypted (Enc) system settings")]
        public static string DecryptPassword(this string data, string key)
        {
            if (key.IsNullOrEmpty()) return data;
            return StripData(data.DecryptAes(key));
        }

        private static string FillData(string data)
        {
            var res = "";
            var chs = data.ToCharArray();

            foreach (char ch in chs)
            {
                res = res + ch + RandomChar();
            }

            return res;
        }

        private static string StripData(string data)
        {
            var res = "";
            var chs = data.ToCharArray();
            for (int i = 0; i < data.Length; i += 2)
            {
                res += chs[i];
            }

            return res;
        }

        /// <summary>
        /// Generates a random key of the specified length.
        /// </summary>
        public static string RandomKey(int length)
        {
            lock (LockObj)
            {
                if (random == null)
                    random = new CryptoRandom();

                byte[] tokenData = new byte[length];
                random.GetBytes(tokenData);
                return Convert.ToBase64String(tokenData);
            }
        }

        /// <summary>
        /// Generates a random byte array of the specified length.
        /// </summary>
        public static byte[] RandomBytes(int length)
        {
            lock (LockObj)
            {
                if (random == null)
                    random = new CryptoRandom();

                byte[] tokenData = new byte[length];
                random.GetBytes(tokenData);
                return tokenData;
            }
        }

        public static string RandomCode(int length, bool incSimilarChars = true)
        {
            const string charOk = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string similar = "125680ijloBGIOQZ";

            lock (LockObj)
            {
                random ??= new CryptoRandom();

                var res = "";
                while (res.Length < length)
                {
                    var c = (char)random.Next(32, 126);
                    if (charOk.Contains(c) && (incSimilarChars || !similar.Contains(c))) res += c;
                }

                return res;
            }
        }

        /// <summary>
        /// Generates a 128-bit encryption key.
        /// </summary>
        public static string Key128()
        {
            lock (LockObj)
            {
                if (random == null)
                    random = new CryptoRandom();

                byte[] tokenData = new byte[64];
                random.GetBytes(tokenData);
                var sb = new StringBuilder();
                foreach (var t in tokenData)
                {
                    sb.Append(t.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
```