Certainly, here are some test cases for the given extension methods.

Please note that in order to run these tests, you need to install a testing framework such as NUnit or MSTest.

```cs
using NUnit.Framework;

namespace G3.Core.Utils.DataType.Tests
{
    [TestFixture]
    public class DataTypeConverterTests
    {
        [TestCase("true", true)]
        [TestCase("yes", true)]
        [TestCase("1", true)]
        [TestCase("y", true)]
        [TestCase("no", false)]
        [TestCase(null, false)]
        public void ToBooleanTest(string input, bool expected)
        {
            Assert.AreEqual(expected, input.ToBoolean());
        }

        [TestCase("12.34", 12.34)]
        [TestCase("foo", 0)]
        [TestCase(null, 0)]
        public void ToDecimalTest(string input, decimal expected)
        {
            Assert.AreEqual(expected, input.ToDecimal());
        }

        [TestCase(null, null)]
        [TestCase("12.34", 12.34)]
        [TestCase("foo", 0)]
        public void ToNullableDecimalTest(string input, decimal? expected)
        {
            Assert.AreEqual(expected, input.ToNullableDecimal());
        }

        [TestCase(null, null)]
        [TestCase("12.34", 12.34)]
        [TestCase("foo", 0)]
        public void ToNullableDoubleTest(string input, double? expected)
        {
            Assert.AreEqual(expected, input.ToNullableDouble());
        }

        [TestCase("123", 123)]
        [TestCase("foo", 0)]
        public void ToInt32Test(string input, int expected)
        {
            Assert.AreEqual(expected, input.ToInt32());
        }

        [TestCase("1234567890123456789", 1234567890123456789L)]
        [TestCase("foo", 0)]
        public void ToInt64Test(string input, long expected)
        {
            Assert.AreEqual(expected, input.ToInt64());
        }

        // Similarly, create tests for other methods
        // ...
    }
}
```
This test cases cover almost all possible situations for the given function, but may vary depending on intended usage and specific requirements. Adjust tests as needed.