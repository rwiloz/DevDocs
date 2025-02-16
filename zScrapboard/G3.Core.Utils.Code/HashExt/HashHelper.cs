Here are the XML summary comments added to this code:

```csharp
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace G3.Core.Utils.HashExt
{
    /// <summary>
    /// Provides methods for hashing operations.
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// Converts a byte array to a hex string.
        /// </summary>
        /// <param name="ba">The byte array to convert.</param>
        /// <returns>A hex string representation of the byte array.</returns>
        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        /// <summary>
        /// Computes a SHA256 hash for the input data using UTF8 encoding.
        /// </summary>
        /// <param name="data">The data to hash.</param>
        /// <returns>The resulting hash as a string.</returns>
        public static string G3HashSha256Utf8(this string data)
        {
            using var sha256Hash = SHA256.Create();
            return G3Hash(Encoding.UTF8.GetBytes(data));
        }

        /// <summary>
        /// Computes a SHA256 hash for the input data using UTF32 encoding.
        /// </summary>
        /// <param name="data">The data to hash.</param>
        /// <returns>The resulting hash as a string.</returns>
        public static string G3HashSha256Utf32(this string data)
        {
            using var sha256Hash = SHA256.Create();
            return G3Hash(Encoding.UTF32.GetBytes(data));
        }

        /// <summary>
        /// Creates a SHA384 integrity hash from the input string using UTF8 encoding.
        /// </summary>
        /// <param name="rawData">The raw data to hash.</param>
        /// <returns>A string representation of the hash prefixed with "sha384-".</returns>
        public static string Sha384IntegrityHash(this string rawData)
        {
            return Sha384IntegrityHash(Encoding.UTF8.GetBytes(rawData));
        }

        /// <summary>
        /// Creates a SHA384 integrity hash from a byte array.
        /// </summary>
        /// <param name="rawData">The raw data to hash.</param>
        /// <returns>A string representation of the hash prefixed with "sha384-".</returns>
        public static string Sha384IntegrityHash(this byte[] rawData)
        {
            using var sha384Hash = SHA384.Create();
            var bytes = sha384Hash.ComputeHash(rawData);
            return $"sha384-{Convert.ToBase64String(bytes)}";
        }

        /// <summary>
        /// Computes a SHA256 hash for the given byte array.
        /// </summary>
        /// <param name="data">The data to hash.</param>
        /// <returns>The resulting hash as a string.</returns>
        public static string G3Hash(this byte[] data)
        {
            using var sha256Hash = SHA256.Create();
            var bytes = sha256Hash.ComputeHash(data);
            return ByteArrayToHexString(bytes);
        }
    }
}
```