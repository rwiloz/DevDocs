Here are some test cases:

```csharp
using NUnit.Framework;

namespace G3.Core.Utils.Tests
{
    [TestFixture]
    public class FormatExtTests
    {
        [TestCase("123-456", true)]
        [TestCase("123456", false)]
        [TestCase("123-4567", false)]
        public void IsValidBsb_ShouldReturnExpectedResult(string value, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, value.IsValidBsb());
        }

        [TestCase("test.email@gmail.com", true)]
        [TestCase("invalidemail", false)]
        public void IsValidEmail_ShouldReturnExpectedResult(string value, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, value.IsValidEmail());
        }

        [TestCase("0412345678", CultureCodeContants.enAU, true)]
        [TestCase("00112345678", CultureCodeContants.enUS, false)]
        public void IsValidMobile_ShouldReturnExpectedResult(string value, string cultureCode, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, value.IsValidMobile(cultureCode));
        }

        [TestCase("0212345678", CultureCodeContants.enAU, true)]
        [TestCase("216-789-1234", CultureCodeContants.enUS, true)]
        [TestCase("00112345678", CultureCodeContants.enUS, false)]
        [TestCase("2167891234", CultureCodeContants.enUS, false)]
        public void IsValidPhone_ShouldReturnExpectedResult(string value, string cultureCode, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, value.IsValidPhone(cultureCode));
        }
    }
}
```

These tests are checking various scenarios:

- `IsValidBsb()` checks if the string is valid BSB (Bank/State/Branch) number.
- `IsValidEmail()` checks if the string is a valid email address.
- `IsValidMobile()` checks if the string is a valid mobile number by country code.
- `IsValidPhone()` checks if the string is a valid phone number by country code.

In each test, assert function is comparing the expected result with the output of the function under test. It helps to make sure that our validation functions are working as expected.
  
Worth noticing that these test cases cover Australia and the US phone number patterns most commonly used. You may want to add more cases to thoroughly test the code's functionality.
