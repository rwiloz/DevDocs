In order to create test cases for the above function, we will use NUnit testing framework to write the test cases. If your function should add "charset=utf-8" to certain types if they are in the "textTypes" array, and return the original type if it's not in the array, from what I can interpret from the code.

```csharp
using NUnit.Framework;
using G3.Core.Utils.Http;

namespace G3.Core.Utils.Http.Tests
{
    [TestFixture]
    public class HttpHelpersTests
    {
        [Test]
        public void CheckAddUtf8_WhenCalledWithTextHtml_ShouldReturnTextHtmlWithUtf8()
        {
            string result = HttpHelpers.CheckAddUtf8("text/html");
            Assert.That(result, Is.EqualTo("text/html; charset=utf-8"));
        }

        [Test]
        public void CheckAddUtf8_WhenCalledWithApplicationManifestJson_ShouldReturnWithUtf8()
        {
            string result = HttpHelpers.CheckAddUtf8("application/manifest+json");
            Assert.That(result, Is.EqualTo("application/manifest+json; charset=utf-8"));
        }

        [Test]
        public void CheckAddUtf8_WhenCalledWithTextPlain_ShouldReturnOriginal()
        {
            string result = HttpHelpers.CheckAddUtf8("text/plain");
            Assert.That(result, Is.EqualTo("text/plain"));
        }

        [Test]
        public void CheckAddUtf8_WhenCalledWithImageJpeg_ShouldReturnOriginal()
        {
            string result = HttpHelpers.CheckAddUtf8("image/jpeg");
            Assert.That(result, Is.EqualTo("image/jpeg"));
        }

        [Test]
        public void CheckAddUtf8_WhenCalledWithEmptyString_ShouldReturnEmptyString()
        {
            string result = HttpHelpers.CheckAddUtf8("");
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void CheckAddUtf8_WhenCalledWithNull_ShouldReturnNull()
        {
            string result = HttpHelpers.CheckAddUtf8(null);
            Assert.That(result, Is.Null);
        }
    }
}
```
These test cases should give a good coverage for your HttpHelper class. It tests all possible outcomes of the function, including edge cases like empty string and null value.