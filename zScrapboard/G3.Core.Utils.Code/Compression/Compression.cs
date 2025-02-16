Sure, here you go:

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace G3.Core.Utils.Compression
{
    /// <summary>
    /// Provides methods for compressing and decompressing data using GZip and Brotli algorithms.
    /// </summary>
    public static class CompressionHelper
    {
        /// <summary>
        /// Compresses the given data using GZip compression algorithm.
        /// </summary>
        /// <param name="data">Data to compress.</param>
        /// <returns>Compressed data.</returns>
        public static byte[] GZipData(this byte[] data)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var gZipStream = new GZipStream(outputStream, CompressionLevel.Fastest))
                    gZipStream.Write(data, 0, data.Length);

                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// Decompresses the given data using GZip decompression algorithm.
        /// </summary>
        /// <param name="data">Data to decompress.</param>
        /// <returns>Decompressed data.</returns>
        public static byte[] GUnZipData(this byte[] data)
        {
            using (var outputStream = new MemoryStream())
            using (var inputStream = new MemoryStream(data))
            {
                using (var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    gZipStream.CopyTo(outputStream);

                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// Compresses the given data using Brotli compression algorithm.
        /// </summary>
        /// <param name="data">Data to compress.</param>
        /// <param name="compLevel">Compression level.</param>
        /// <returns>Compressed data.</returns>
        public static byte[] BrCompressData(this byte[] data, CompressionLevel compLevel)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var gZipStream = new BrotliStream(outputStream, compLevel))
                    gZipStream.Write(data, 0, data.Length);

                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// Decompresses the given data using Brotli decompression algorithm.
        /// </summary>
        /// <param name="data">Data to decompress.</param>
        /// <returns>Decompressed data.</returns>
        public static byte[] BrUncompressData(this byte[] data)
        {
            using (var outputStream = new MemoryStream())
            using (var inputStream = new MemoryStream(data))
            {
                using (var gZipStream = new BrotliStream(inputStream, CompressionMode.Decompress))
                    gZipStream.CopyTo(outputStream);

                return outputStream.ToArray();
            }
        }
    }
}
```

I have added XML summary comments to describe what each method does, explaining the parameters and the return values. These comments will be shown in IntelliSense when a developer uses these methods elsewhere in the code.