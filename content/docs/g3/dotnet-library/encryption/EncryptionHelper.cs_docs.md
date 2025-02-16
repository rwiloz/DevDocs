---
title: "Encryption Helpers"
description: ""
summary: ""
date: 2023-09-07T16:12:37+02:00
lastmod: 2023-09-07T16:12:37+02:00
draft: false
weight: 900
toc: true
sidebar:
  collapsed: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

# Class: EncryptionHelper

This class provides various utilities for encryption tasks such as generating random numbers, characters, and keys, encoding and decoding passwords, and encrypting and decrypting passwords.

## Properties

1. **random**: Instance of `CryptoRandom` class. This utilises cryptographically secure random number generator.

2. **LockObj**: An object used for thread synchronization during random operations.

## Methods

### 1. **RandomChar**: Generates a random character using the cryptographically secure random number generator. This operation is thread-safe.

### 2. **RandomNumber(int max)**: Returns a cryptographically secure random number which is less than the specified maximum.

### 3. **RandomNumber(int min, int max)**: Returns a cryptographically secure random number within a specified range. 

### 4. **DecodePassword**: Converts an encoded password from Base64 form to text. Only applicable if the password string is not null or empty.

### 5. **EncodePassword**: Converts a text password to Base64. Only applicable if the password is not empty.

### 6. **EncryptPassword**: Uses AES encryption to encrypt the data. Accepts a data string and a key string as arguments. The method is marked as Obsolete.

### 7. **DecryptPassword**: Uses AES decryption to decrypt the data. Accepts a data string and a key string as arguments. The method is commented out and is marked as Obsolete.

### 8. **FillData**: Used as a part of the encrypting function, this method alternates each character of the input string with a random character and returns the resultant string.

### 9. **StripData**: This method is used by the decrypting function. It takes in the encrypted string, removes the characters added during encryption and returns the decrypted string.

### 10. **RandomKey**: Generates random bytes of a specified length and returns them as a Base64 string.

### 11. **RandomBytes**: Generates and returns random bytes of the specified length.

### 12. **RandomCode**: Generates a specified length string of random alphanumeric characters.

### 13. **Key128**: Generates a cryptographically secure 128-bit key. Returns the key as a hexadecimal string.

### Note: Some methods are commented out and others are marked as deprecated suggesting a possible migration towards a different encryption system.