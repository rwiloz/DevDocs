# AesUtility Class

This class is a utility class defined in the `G3.Core.Utils.Encryptions` namespace. It provides static methods for encrypting and decrypting data using the AES (Advanced Encryption Standard) cryptographic algorithm.

## Methods

### `DecryptAes(this string textToBeDecrypted, string password, string salt = null, bool utf8 = false)` 

This extension method decrypts a Base64 string using the provided password and optional salt. If no salt is provided, it defaults to the length of the password. The string is first converted from Base64 to bytes which are then decrypted, and the result is converted back to a string. If an error occurs during the process, the original string (i.e. the input `textToBeDecrypted`) is returned. 

### `DecryptAesUtf8(this string textToBeDecrypted, string password, string salt = null)`

This extension method is a specific implementation of `DecryptAes()` which enforces UTF8 encoding. It simply calls `DecryptAes()` with the `utf8` parameter set to `true`.

### `EncryptAes(this string textToBeEncrypted, string password, string salt = null, bool utf8 = false)`

This extension method encrypts a string using the specified password and optional salt. If no salt is provided, it defaults to the length of the password. The string is first converted to bytes and then encrypted. The resulting encrypted bytes are returned as a Base64 string.

### `EncryptAesUtf8(this string textToBeEncrypted, string password, string salt = null)`

This extension method is a specific implementation of `EncryptAes()` which enforces the use of UTF8 encoding. The method calls `EncryptAes()` with the `utf8` parameter set to `true`.

### `EncryptAes(this string plainText, byte[] key, byte[] iv)`

This extension method encrypts a plain text string using the provided key and initialization vector (IV). The encrypted text is returned as a Base64 string.

### `DecryptAes(this string cipherText, byte[] key, byte[] iv)`

This extension method decrypts a Base64-encoded cipher text string using the provided key and initialization vector (IV). The decrypted text is returned as a string.