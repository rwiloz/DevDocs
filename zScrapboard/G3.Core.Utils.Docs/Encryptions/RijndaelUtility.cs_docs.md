# Class: RijndaelUtility

This class belongs to the G3.Core.Utils.Encryptions namespace and serves as a utility for performing Rijndael encryption and decryption.

## Method: Decrypt

```csharp
public static string Decrypt(string textToBeDecrypted, string password, string salt = null)
```

The `Decrypt` method is a static method that takes three parameters (`textToBeDecrypted`, `password`, and `salt`) to decrypt a given text. It uses the RijndaelManaged algorithm for decryption. If the `salt` parameter is not provided, then password length is used for creating salt bytes. The method finally returns the decrypted data in the form of a string. 

In case of any exception, the original `textToBeDecrypted` value is returned.

## Method: Encrypt

```csharp
public static string Encrypt(string textToBeEncrypted, string password, string salt = null)
```

The `Encrypt` method is a static method as well, that takes three parameters (`textToBeEncrypted`, `password`, and `salt`) for the purpose of encryption. Like the `Decrypt` method, it uses RijndaelManaged algorithm for encrypting the given text and the encryption keys are derived from the `password` and `salt` values.

The `salt` is used to provide an additional layer of security to the encryption process. If no salt value is provided, the length of the password is used. This method returns the encrypted data as a Base64 string.

Remember, any plaintext written into the `CryptoStream` object is encrypted and afterwards, `FlushFinalBlock` is called on the `CryptoStream` object to finish the encryption process and to make sure that the final block is written to the underlying data source. Then, the encrypted data in the `MemoryStream` object is returned as an array of bytes, which is then converted into a Base64 string.