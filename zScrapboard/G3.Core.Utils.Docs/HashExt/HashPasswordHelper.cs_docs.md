---
title: "Hash Password Helper"
date: "2023-10-01"
description: "Documentation for the `HashPasswordHelper` class and associated cryptography functionalities."
---

# Hash Password Helper

This documentation covers the `HashPasswordHelper` class and related cryptography utilities, which provide methods for hashing passwords securely using the PBKDF2 algorithm and implementing custom cryptographic functions. 

## Namespace

The classes are defined under the namespace `G3.Core.Utils.HashExt`.

## Dependencies

This code relies on the following namespaces and libraries:
- `System`
- `System.Collections.Generic`
- `System.IO`
- `System.Security.Cryptography`
- `System.Text`
- `Microsoft.AspNetCore.Cryptography.KeyDerivation`

## Classes and Methods

### `HashPasswordHelper` Class

A static utility class for hashing passwords.

#### Methods

- **`HashPassWord(this string password)`**

  Hashes the provided password using the PBKDF2 algorithm. 

  - **Parameters:**
    - `password`: A string representing the password to hash.

  - **Returns:** 
    - A base64 encoded string of the hashed password. Returns `null` if the password is `null` or less than 6 characters in length.

- **`HashPasswordSentinel(this string password, Guid saltGuid, string key)`**

  Hashes a password for G2Oss migrated users using a custom cryptography method.

  - **Parameters:**
    - `password`: A string representing the password to hash.
    - `saltGuid`: A `Guid` used as a salt.
    - `key`: A string key used for hashing.

  - **Returns:** 
    - A base64 encoded string of the hashed password using Sentinel's custom hashing.

### `SentinelEncryptionRequest` Class

This class is a data model for managing encryption requests.

#### Properties

- **`Value`**
  
  A byte array representing the data to encrypt.

- **`IV`**

  The initial vector for the encryption algorithm.

- **`Key`**

  The encryption key for the cryptography algorithm.

### `SentinelCryptography` Class

Contains static methods for custom encryption and hashing operations.

#### Methods

- **`AdjustByteArray(byte[] value, int newSize)`**

  Resizes a byte array to the specified size, adjusting its content accordingly.

- **`GenerateIV(byte[] salt = null)`**

  Generates an initial vector (IV) for encryption. Optionally uses a salt value.

- **`Encrypt(SentinelEncryptionRequest request)`**

  Encrypts the specified data following the encryption parameters provided in the `SentinelEncryptionRequest`.

- **`SentinelHash(byte[] request)`**

  Computes a SHA-256 hash for the given byte array.

- **`CreatePasswordHash(Guid Id, string password, string key)`**

  Creates a password hash using a GUID, a password, and a key. The result is hashed after encryption.

- **`SentinelPasswordHash(Guid id, string password, string key)`**

  Provides an interface for generating a hashed password, integrating several cryptographic processes.

## Usage

To use these utilities, you instantiate a string representing the password and call the required extension method on the string object. For Sentinel specific hashing, include a `Guid` and key as parameters.

```csharp
string password = "your_password";
string hashedPassword = password.HashPassWord();

Guid saltGuid = Guid.NewGuid();
string key = "your_key";
string sentinelHashedPassword = password.HashPasswordSentinel(saltGuid, key);
```
