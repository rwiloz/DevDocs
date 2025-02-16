---
title: AesUtility Class Documentation
description: This document provides an overview and usage details for the AesUtility class, which supports AES encryption and decryption.
date: 2023-10-25
categories: 
  - Encryption
  - Security
tags: 
  - C#
  - AES
  - Cryptography
---

# AesUtility Class

The `AesUtility` class offers static methods for encrypting and decrypting strings using the Advanced Encryption Standard (AES). It provides methods that handle both UTF-8 and Unicode encoding, and supports custom salt and password-based encryption.

## Namespace

`G3.Core.Utils.Encryptions`

## Dependencies

```csharp
using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
```

## Class Definition

```csharp
public static class AesUtility
```

### Methods

#### DecryptAes

```csharp
public static string DecryptAes(this string textToBeDecrypted, string password, string salt = null, bool utf8 = false)
```

- **Description**: Decrypts a string using AES encryption.
- **Parameters**:
  - `textToBeDecrypted`: The base64 encoded string to decrypt.
  - `password`: The password used for decryption.
  - `salt`: An optional salt to add security (default is `null`).
  - `utf8`: A boolean indicating if the output should be UTF-8 encoded (default is `false`).
- **Returns**: Returns the decrypted string.

#### DecryptAesUtf8

```csharp
public static string DecryptAesUtf8(this string textToBeDecrypted, string password, string salt = null)
```

- **Description**: A utility method to decrypt a UTF-8 encoded string using AES.
- **Parameters**:
  - `textToBeDecrypted`: The base64 encoded string to decrypt.
  - `password`: The password used for decryption.
  - `salt`: An optional salt to add security (default is `null`).
- **Returns**: Returns the decrypted string.

#### EncryptAes

```csharp
public static string EncryptAes(this string textToBeEncrypted, string password, string salt = null, bool utf8 = false)
```

- **Description**: Encrypts a string using AES encryption.
- **Parameters**:
  - `textToBeEncrypted`: The plaintext string to encrypt.
  - `password`: The password used for encryption.
  - `salt`: An optional salt to add security (default is `null`).
  - `utf8`: A boolean indicating if the input is UTF-8 encoded (default is `false`).
- **Returns**: Returns a base64 encoded string of the encrypted text.

#### EncryptAesUtf8

```csharp
public static string EncryptAesUtf8(this string textToBeEncrypted, string password, string salt = null)
```

- **Description**: A utility method to encrypt a UTF-8 encoded string using AES.
- **Parameters**:
  - `textToBeEncrypted`: The plaintext string to encrypt.
  - `password`: The password used for encryption.
  - `salt`: An optional salt to add security (default is `null`).
- **Returns**: Returns a base64 encoded string of the encrypted text.

#### EncryptAes Overload

```csharp
public static string EncryptAes(this string plainText, byte[] key, byte[] iv)
```

- **Description**: Encrypts a string with a specified key and initialization vector.
- **Parameters**:
  - `plainText`: The plaintext string to encrypt.
  - `key`: A byte array that contains the secret key.
  - `iv`: A byte array that contains the initialization vector.
- **Returns**: Returns a base64 encoded string of the encrypted text.

#### DecryptAes Overload

```csharp
public static string DecryptAes(this string cipherText, byte[] key, byte[] iv)
```

- **Description**: Decrypts a string with a specified key and initialization vector.
- **Parameters**:
  - `cipherText`: The base64 encoded string to decrypt.
  - `key`: A byte array that contains the secret key.
  - `iv`: A byte array that contains the initialization vector.
- **Returns**: Returns the decrypted string.

### Remarks

This class is designed to simplify encryption and decryption using AES. It provides options for both UTF-8 and Unicode encoding. While it currently uses `PasswordDeriveBytes` which is known to be dated, there are ongoing considerations for migrating to more modern approaches such as Argon2id.

For password hashing, consider using solutions like `Konscious.Security.Cryptography` with Argon2id for stronger security. Examples are provided but not implemented in this class.

#### Future Work

Newer encryption methods and key derivation techniques are recommended for added security. Consider migration to a more modern cryptographic library.

END OF DOCUMENT
```