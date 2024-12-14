Here are the test cases for the CompressionHelper class:

```csharp
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using G3.Core.Utils.Compression;
using Xunit;

namespace G3.Core.Utils.Compression.Tests
{
    public class CompressionHelperTests
    {
        private readonly byte[] testData;

        public CompressionHelperTests()
        {
            testData = Encoding.UTF8.GetBytes("This is a test data for compression and decompression");
        }

        [Fact]
        public void GZipData_GUnZipData_Test()
        {
            var compressedData = testData.GZipData();
            Assert.NotNull(compressedData);

            var decompressedData = compressedData.GUnZipData();
            Assert.NotNull(decompressedData);

            var originalData = Encoding.UTF8.GetString(decompressedData);
            Assert.Equal("This is a test data for compression and decompression", originalData);
        }

        [Fact]
        public void BrCompressData_BrUncompressData_Test()
        {
            var compressedData = testData.BrCompressData(CompressionLevel.Fastest);
            Assert.NotNull(compressedData);

            var decompressedData = compressedData.BrUncompressData();
            Assert.NotNull(decompressedData);

            var originalData = Encoding.UTF8.GetString(decompressedData);
            Assert.Equal("This is a test data for compression and decompression", originalData);
        }
    }
}
```

There are two xUnit tests here which compress the given byte data and decompress it back. The tests verify that the original data is as expected after the decompression. The testData is initialized in the constructor of the test class and used for both tests. This test suite will ensure that the CompressionHelper class properly compresses and decompresses byte data.