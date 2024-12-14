# CompressionHelper Class

This utility class named `CompressionHelper` is part of the namespace `G3.Core.Utils.Compression`. It provides methods for compressing and decompressing data using GZip and Brotli compression algorithms.

## Methods

1. **GZipData(byte[] data)**: This method is an extension method that takes an array of bytes as input, performs GZip compression at the fastest compression level and returns the compressed data as a byte array. 

2. **GUnZipData(byte[] data)**: This extension method receives an array of bytes as input, decompresses the GZip compressed data and returns the uncompressed data as a byte array.

3. **BrCompressData(byte[] data, CompressionLevel compLevel)**: Similar to the `GZipData` method, but instead uses the Brotli compression algorithm. The compression level can be specified by passing the `CompressionLevel` enum as a parameter.

4. **BrUncompressData(byte[] data)**: This method decompresses data that was compressed using the Brotli compression algorithm and returns the decompressed data as a byte array.

The essential classes used in this utility are `System.IO.MemoryStream`, `System.IO.Compression.GZipStream`, and `System.IO.Compression.BrotliStream` from the .NET Framework.