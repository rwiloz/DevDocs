---
title: "HashHelper Class Documentation"
date: 2023-10-20
slug: "hash-helper-class"
draft: false
tags: ["C#", "Hashing", "Utilities", "Security"]
---

# HashHelper Class

The `HashHelper` class provides utility methods for hashing data using different algorithms like SHA-256 and SHA-384. It allows conversion of byte arrays to hexadecimal strings and provides specific methods for creating hash strings from UTF-8 and UTF-32 encoded inputs.

## Namespace

`G3.Core.Utils.HashExt`

## Methods

### ByteArrayToHexString

```csharp
public static string ByteArrayToHexString(byte[] ba)
```

- **Description**: Converts a byte array to its hexadecimal string representation.
- **Parameters**: 
  - `byte[] ba`: The byte array to convert.
- **Returns**: `string` - The hexadecimal string representation of the byte array.

### G3HashSha256Utf8

```csharp
public static string G3HashSha256Utf8(this string data)
```

- **Description**: Computes the SHA-256 hash of a string encoded in UTF-8.
- **Parameters**: 
  - `string data`: The input string to hash.
- **Returns**: `string` - The hexadecimal representation of the SHA-256 hash.

### G3HashSha256Utf32

```csharp
public static string G3HashSha256Utf32(this string data)
```

- **Description**: Computes the SHA-256 hash of a string encoded in UTF-32.
- **Parameters**: 
  - `string data`: The input string to hash.
- **Returns**: `string` - The hexadecimal representation of the SHA-256 hash.

### Sha384IntegrityHash (String Overload)

```csharp
public static string Sha384IntegrityHash(this string rawData)
```

- **Description**: Computes the SHA-384 integrity hash of a string using UTF-8 encoding.
- **Parameters**: 
  - `string rawData`: The input string to hash.
- **Returns**: `string` - The base64-encoded SHA-384 hash, prefixed with `sha384-`.

### Sha384IntegrityHash (Byte Array Overload)

```csharp
public static string Sha384IntegrityHash(this byte[] rawData)
```

- **Description**: Computes the SHA-384 integrity hash of a byte array.
- **Parameters**: 
  - `byte[] rawData`: The byte array to hash.
- **Returns**: `string` - The base64-encoded SHA-384 hash, prefixed with `sha384-`.

### G3Hash

```csharp
public static string G3Hash(this byte[] data)
```

- **Description**: Computes the SHA-256 hash of a byte array.
- **Parameters**: 
  - `byte[] data`: The byte array to hash.
- **Returns**: `string` - The hexadecimal representation of the SHA-256 hash.
```