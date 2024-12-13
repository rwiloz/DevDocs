using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace G3.Core.Utils.Compression
{
    public static class CompressionHelper
    {
        public static byte[] GZipData(this byte[] data)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var gZipStream = new GZipStream(outputStream, CompressionLevel.Fastest))
                    gZipStream.Write(data, 0, data.Length);

                return outputStream.ToArray();
            }
        }

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

        public static byte[] BrCompressData(this byte[] data, CompressionLevel compLevel)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var gZipStream = new BrotliStream(outputStream, compLevel))
                    gZipStream.Write(data, 0, data.Length);

                return outputStream.ToArray();
            }
        }

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
