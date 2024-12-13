using G3.Core.Utils.Strings;
using System;
using System.Text;

namespace G3.Core.Utils.Encryptions
{
    public static class EncryptionHelper
    {

        private static CryptoRandom random;
        private static readonly object LockObj = new();

        private static char RandomChar()
        {
            lock (LockObj)
            {
                if (random == null)
                    random = new CryptoRandom();

                return (char)random.Next(32, 126);
            }
        }

        public static int RandomNumber(int max)
        {
            lock (LockObj)
            {
                if (random == null)
                    random = new CryptoRandom();

                return random.Next(max);
            }
        }

        public static int RandomNumber(int min, int max)
        {
            lock (LockObj)
            {
                if (random == null)
                    random = new CryptoRandom();

                return random.Next(min, max);
            }
        }

        public static string DecodePassword(this string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                password = password.Base64Decode().DecodeText();
            }

            return password;
        }

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

        //public static string EncryptPasswordUtf8(this string data, string key)
        //{
        //    if (key.IsNullOrEmpty()) return data;
        //    return FillData(data).EncryptAesUtf8(key);
        //}

        //public static string DecryptPasswordUtf8(this string data, string key)
        //{
        //    if (key.IsNullOrEmpty()) return data;
        //    return StripData(data.DecryptAesUtf8(key));
        //}

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

        //public static string MakeKey(int size = 128)
        //{
        //    var bytes = new byte[size];
        //    using (var rng = new RNGCryptoServiceProvider())
        //    {
        //        rng.GetBytes(bytes);
        //        return Convert.ToBase64String(bytes);
        //    }
        //}

    }
}
