---
title: CompressionHelper Utility
date: 2023-10-01
description: A utility for compressing and decompressing byte arrays using GZip and Brotli algorithms.
menu:
  main:
    parent: utilities
---

# CompressionHelper Utility

The `CompressionHelper` class provides static methods for compressing and decompressing byte arrays using the GZip and Brotli compression algorithms. These methods enable efficient data size reduction and retrieval for byte streams in .NET applications.

## Namespace

`G3.Core.Utils.Compression`

## Methods

### GZipData

```csharp
public static byte[] GZipData(this byte[] data)
```

Compresses the provided byte array using the GZip algorithm.

- **Parameters**: 
  - `data`: The byte array to be compressed.
- **Returns**: 
  - A compressed byte array.

### GUnZipData

```csharp
public static byte[] GUnZipData(this byte[] data)
```

Decompresses the provided GZip-compressed byte array.

- **Parameters**: 
  - `data`: The GZip-compressed byte array to be decompressed.
- **Returns**: 
  - A decompressed byte array.

### BrCompressData

```csharp
public static byte[] BrCompressData(this byte[] data, CompressionLevel compLevel)
```

Compresses the provided byte array using the Brotli algorithm with a specified compression level.

- **Parameters**: 
  - `data`: The byte array to be compressed.
  - `compLevel`: The desired compression level, using the `CompressionLevel` enumeration.
- **Returns**: 
  - A compressed byte array.

### BrUncompressData

```csharp
public static byte[] BrUncompressData(this byte[] data)
```

Decompresses the provided Brotli-compressed byte array.

- **Parameters**: 
  - `data`: The Brotli-compressed byte array to be decompressed.
- **Returns**: 
  - A decompressed byte array.

## Usage

This utility can be particularly useful in scenarios where reducing data size for storage or transmission is critical. It leverages .NET's built-in compression streams to efficiently manage data compression and decompression tasks.

### Example

```csharp
byte[] rawData = Encoding.UTF8.GetBytes("Your data here");
byte[] compressedData = rawData.GZipData();
byte[] decompressedData = compressedData.GUnZipData();
```

In this example, a string is converted to a byte array, compressed using GZip, and then decompressed to retrieve the original data.

## Additional Notes

- Ensure that the input byte arrays are not null to prevent runtime exceptions.
- The compression level for Brotli can significantly impact performance and resulting size, so choose a level that balances speed and compression ratio for your specific use case.
