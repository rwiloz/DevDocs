Here are test cases to cover the main functionalities of the code:

```csharp
using G3.Core.Utils.DnsExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G3.Tests
{
    [TestClass]
    public class DnsExtensionsTests
    {
        [TestMethod]
        public void TestToIpV4Address_ValidAddress_ReturnsValidV4Address()
        {
            var result = "192.168.0.1".ToIpV4Address();
            Assert.AreEqual("192.168.0.1", result);
        }

        [TestMethod]
        public void TestIsValidIpAddress_InvalidAddress_ReturnsFalse()
        {
            var result = "12.345.67.8".IsValidIpAddress();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsValidIpAddress_ValidAddress_ReturnsTrue()
        {
            var result = "192.168.0.1".IsValidIpAddress();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsIpV6_ValidV6Address_ReturnsTrue()
        {
            var result = "2001:0db8:0000:0042:0000:8a2e:0370:7334".IsIpV6();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsIpV6_ValidV4Address_ReturnsFalse()
        {
            var result = "192.168.0.1".IsIpV6();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsPrivateAddress_PrivateAddress_ReturnsTrue()
        {
            var result = "192.168.0.1".IsPrivateAddress();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsPrivateAddress_PublicAddress_ReturnsFalse()
        {
            var result = "8.8.8.8".IsPrivateAddress();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIp4Matches_ValidAddressIPList_ReturnsTrue()
        {
            var result = "192.168.0.1".Ip4Matches(new string[] { "192.168.0.1", "192.168.0.2" });
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIp4Matches_InvalidAddressIPList_ReturnsFalse()
        {
            var result = "8.8.8.8".Ip4Matches(new string[] { "192.168.0.1", "192.168.0.2" });
            Assert.IsFalse(result);
        }   
    }
}
```
Please replace my placeholders like `"8.8.8.8"` or `"2001:0db8:0000:0042:0000:8a2e:0370:7334"` with real valid or invalid IPs for your needs. Also Ip6Matches and IsWhiteListed methods can't be tested without implementing external dependencies like whiteListIps.