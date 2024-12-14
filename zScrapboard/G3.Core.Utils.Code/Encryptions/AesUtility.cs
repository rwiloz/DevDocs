Here's the code with inline XML summary comments:

```CSharp
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
    /// <summary>
    /// Provides utility methods for AES encryption and decryption.
    /// </summary>
    public static class AesUtility
    {
        /// <summary>
        /// Decrypts the specified text using AES algorithm.
        /// </summary>
        /// <param name="textToBeDecrypted">The text to be decrypted.</param>
        /// <param name="password">The password used for decryption.</param>
        /// <param name="salt">The salt used for decryption. If null, the length of password is used.</param>
        /// <param name="utf8">A value indicating whether to use UTF8 encoding. If false, Unicode encoding is used.</param>
        /// <returns>The decrypted text.</returns>
        public static string DecryptAes(this string textToBeDecrypted, string password, string salt = null, bool utf8 = false)
        //...

        /// <summary>
        /// Decrypts the specified text using AES algorithm with UTF8 encoding.
        /// </summary>
        /// <param name="textToBeDecrypted">The text to be decrypted.</param>
        /// <param name="password">The password used for decryption.</param>
        /// <param name="salt">The salt used for decryption. If null, the length of password is used.</param>
        /// <returns>The decrypted text.</returns>
        public static string DecryptAesUtf8(this string textToBeDecrypted, string password, string salt = null)
        //...

        /// <summary>
        /// Encrypts the specified text using AES algorithm.
        /// </summary>
        /// <param name="textToBeEncrypted">The text to be encrypted.</param>
        /// <param name="password">The password used for encryption.</param>
        /// <param name="salt">The salt used for encryption. If null, the length of password is used.</param>
        /// <param name="utf8">A value indicating whether to use UTF8 encoding. If false, Unicode encoding is used.</param>
        /// <returns>The encrypted text.</returns>
        public static string EncryptAes(this string textToBeEncrypted, string password, string salt = null, bool utf8 = false)
        //...

        /// <summary>
        /// Encrypts the specified text using AES algorithm with UTF8 encoding.
        /// </summary>
        /// <param name="textToBeEncrypted">The text to be encrypted.</param>
        /// <param name="password">The password used for encryption.</param>
        /// <param name="salt">The salt used for encryption. If null, the length of password is used.</param>
        /// <returns>The encrypted text.</returns>
        public static string EncryptAesUtf8(this string textToBeEncrypted, string password, string salt = null)
        //...

        /// <summary>
        /// Encrypts the specified plain text using AES algorithm with provided key and initialization vector (IV).
        /// </summary>
        /// <param name="plainText">The plain text to encrypt.</param>
        /// <param name="key">The key for encryption.</param>
        /// <param name="iv">The initialization vector (IV) for encryption.</param>
        /// <returns>The encrypted text in base64 format.</returns>
        public static string EncryptAes(this string plainText, byte[] key, byte[] iv)
        //...

        /// <summary>
        /// Decrypts the specified cipher text using AES algorithm with provided key and initialization vector (IV).
        /// </summary>
        /// <param name="cipherText">The cipher text to decrypt.</param>
        /// <param name="key">The key for decryption.</param>
        /// <param name="iv">The initialization vector (IV) for decryption.</param>
        /// <returns>The decrypted text.</returns>
        public static string DecryptAes(this string cipherText, byte[] key, byte[] iv)
        //...
    }
}
```
In the above code, XML documentation comments have been added above method definitions. XML comments are used to add documentation to your code that is embedded within the source code itself. These comments can be used by IntelliSense in Visual Studio to provide tooltips when using these methods elsewhere in your code, and can also be extracted to generate API documentation.