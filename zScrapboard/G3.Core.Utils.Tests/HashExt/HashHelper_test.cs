Sure, here are some unit tests using MSTest for the methods you've defined.

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G3.Core.Utils.HashExt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HashHelperTests
{
    [TestClass]
    public class HashHelperTests
    {
        [TestMethod]
        public void ByteArrayToHexString_GivenByteArray_ReturnsExpectedHexadecimalString()
        {
            var byteArray = Encoding.UTF8.GetBytes("test value");
            var result = HashHelper.ByteArrayToHexString(byteArray);
            Assert.IsTrue(result.All(x => "0123456789abcdef".Contains(x)));
        }

        [TestMethod]
        public void G3HashSha256Utf8_GivenString_ReturnsExpectedHash()
        {
            var input = "test value";
            var result = input.G3HashSha256Utf8();
            using var sha256Hash = SHA256.Create();
            var expectedHash = HashHelper.ByteArrayToHexString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input)));
            Assert.AreEqual(expectedHash, result);
        }

        [TestMethod]
        public void G3HashSha256Utf32_GivenString_ReturnsExpectedHash()
        {
            var input = "test value";
            var result = input.G3HashSha256Utf32();
            using var sha256Hash = SHA256.Create();
            var expectedHash = HashHelper.ByteArrayToHexString(sha256Hash.ComputeHash(Encoding.UTF32.GetBytes(input)));
            Assert.AreEqual(expectedHash, result);
        }

        [TestMethod]
        public void Sha384IntegrityHash_GivenString_ReturnsExpectedHash()
        {
            var input = "test value";
            var result = input.Sha384IntegrityHash();
            using var sha384Hash = SHA384.Create();
            var bytes = sha384Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var expectedHash = $"sha384-{Convert.ToBase64String(bytes)}";
            Assert.AreEqual(expectedHash, result);
        }

        [TestMethod]
        public void G3Hash_GivenByteArray_ReturnsExpectedHash()
        {
            var input = Encoding.UTF8.GetBytes("test value");
            var result = input.G3Hash();
            using var sha256Hash = SHA256.Create();
            var expectedHash = HashHelper.ByteArrayToHexString(sha256Hash.ComputeHash(input));
            Assert.AreEqual(expectedHash, result);
        }
    }
}
```

These tests cover the basic functionalities of each your methods, however, these tests only cover happy path scenarios. You might consider adding additional tests to cover edge cases or incorrect usages of your methods. For example, you might want to add tests for null or empty string inputs, or data that could potentially cause an exception to be thrown.