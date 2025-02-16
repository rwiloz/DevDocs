---
title: RijndaelUtility Class Documentation
description: Documentation for the RijndaelUtility class that provides methods for encrypting and decrypting data using Rijndael symmetric encryption.
date: 2023-10-15
---

# RijndaelUtility Class

Namespace: G3.Core.Utils.Encryptions

The `RijndaelUtility` class provides static methods for encrypting and decrypting text using the Rijndael symmetric encryption algorithm. This class simplifies the process of converting plain text to encrypted data and vice versa by leveraging the capabilities of the Rijndael algorithm.

## Methods

### Decrypt

```csharp
public static string Decrypt(string textToBeDecrypted, string password, string salt = null)
```

Decrypts the specified text using a password and an optional salt. The method uses a `RijndaelManaged` object to perform the decryption.

#### Parameters

- `textToBeDecrypted`: `string`
  - The base64 encoded string that needs to be decrypted.
  
- `password`: `string`
  - The password used to generate the decryption key.
  
- `salt`: `string` (optional)
  - An optional salt value used to enhance the complexity of the decryption key. If no salt is provided, the length of the password is used as the salt.

#### Returns

- `string`: The decrypted text as a plain string. If decryption fails, it returns the original input text.

### Encrypt

```csharp
public static string Encrypt(string textToBeEncrypted, string password, string salt = null)
```

Encrypts the specified text using a password and an optional salt. The method uses a `RijndaelManaged` object to perform the encryption.

#### Parameters

- `textToBeEncrypted`: `string`
  - The plain text string that needs to be encrypted.
  
- `password`: `string`
  - The password used to generate the encryption key.
  
- `salt`: `string` (optional)
  - An optional salt value used to enhance the complexity of the encryption key. If no salt is provided, the length of the password is used as the salt.

#### Returns

- `string`: A base64 encoded string representing the encrypted data.

## Usage

The `RijndaelUtility` class is intended for scenarios where text needs to be securely encrypted and decrypted using a symmetric key encryption algorithm. It is particularly useful for encrypting sensitive data such as passwords, tokens, and confidential information.

## Example

```csharp
string originalText = "Hello, World!";
string password = "SecurePassword123";

// Encrypt the original text
string encryptedText = RijndaelUtility.Encrypt(originalText, password);

// Decrypt the encrypted text
string decryptedText = RijndaelUtility.Decrypt(encryptedText, password);
```

## Reference

For further reading and more detailed examples, you can visit the original source: [DotNetSpider Encryption/Decryption Sample](http://www.dotnetspider.com/resources/5096-Encryption-decryption-sample.aspx).
