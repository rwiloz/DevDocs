---
title: "EncryptionHelper Class Documentation"
date: 2023-10-10
description: "A detailed explanation of the EncryptionHelper class within the G3.Core.Utils.Encryptions namespace, focusing on its utility for random generation and password operations."
---

# EncryptionHelper Class

## Overview
The `EncryptionHelper` class, located in the `G3.Core.Utils.Encryptions` namespace, provides a suite of static methods used for generating random data and encoding and decoding passwords. The class is designed to simplify encryption-related tasks through its utility methods.

## Usage

### Namespace
Make sure to include the necessary namespaces in your file:

```csharp
using G3.Core.Utils.Encryptions;
using G3.Core.Utils.Strings;
```

### Methods

#### Random Generation Methods

- **RandomChar**
  - Returns a random character.
  
- **RandomNumber**
  - Overload 1: `RandomNumber(int max)`: Returns a random number between 0 and `max`.
  - Overload 2: `RandomNumber(int min, int max)`: Returns a random number between `min` and `max`.

- **RandomKey**
  - Generates a random key of specified byte length and returns it as a Base64-encoded string.
  
- **RandomBytes**
  - Returns a byte array filled with random bytes of specified length.

- **RandomCode**
  - Returns a random alphanumeric string of specified length. The parameter `incSimilarChars` determines if similar characters should be included.

- **Key128**
  - Generates a 128-bit key in hexadecimal string format.

#### Password Encoding and Decoding

- **DecodePassword**
  - Decodes a Base64-encoded string (password) to its plain text representation.

- **EncodePassword**
  - Encodes a string (password) into Base64 format.

#### Obsolete Methods

Note: The following methods are marked as obsolete and should be migrated to the `KeyManaged Encrypted (Enc) system settings`.

- **EncryptPassword**
  - Encrypts data using AES encryption with a specified key.
  
- **DecryptPassword**
  - Decrypts data encrypted with AES using a specified key.

#### Internal Helper Methods

These methods assist in preparing data for encryption and decryption:

- **FillData**
  - Intersperses random characters within the original string to prepare it for encryption.
  
- **StripData**
  - Removes interspersed random characters from the decrypted string to recover the original data.

## Thread Safety
The class employs a `LockObj` to ensure thread safety when generating random data.

## Example
```csharp
var password = "HelloWorld";
string encodedPassword = password.EncodePassword();
string decodedPassword = encodedPassword.DecodePassword();
Console.WriteLine($"Encoded: {encodedPassword}, Decoded: {decodedPassword}");
```

## Remarks
- This class depends on the `CryptoRandom` class for randomness, which must be properly initialized.
- Methods marked as obsolete should be avoided in new implementations.

## Conclusion
The `EncryptionHelper` class is a versatile utility meant for secure random data generation and simple password encryption and decryption tasks, featuring easy-to-use methods that cater to both basic and advanced scenarios.
```