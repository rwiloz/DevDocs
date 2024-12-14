You can use NUnit as your testing framework, to write several test cases for the Metaphone class. The NUnit library can be installed through the NuGet Package Manager in Visual Studio. Below is an example of how you might start by testing the Encode method under various different scenarios:

```csharp
using NUnit.Framework;
using G3.Core.Utils.Strings;

namespace G3.Tests.Utils.Strings
{
    [TestFixture]
    public class MetaphoneTests
    {
        private Metaphone metaphone;

        [SetUp]
        public void Setup()
        {
            metaphone = new Metaphone();
        }
        
        [Test]
        public void Encode_ReturnCorrectEncodedString_WhenTextHasVowels()
        {
            string expected = "AC";
            string actual = metaphone.Encode("AEIOU");
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Encode_ReturnCorrectEncodedString_WhenTextHasNonVowels()
        {
            string expected = "BCDF";
            string actual = metaphone.Encode("BCDF");
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Encode_ReturnCorrectEncodedString_WhenTextHasNumericValues()
        {
            string expected = "";
            string actual = metaphone.Encode("1234567890");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Normalize_ReturnsCorrectString_WhenTextIncludesSpecialCharacters()
        {
            string expected = "HELLOWORLD";
            string actual = metaphone.Normalize("Hello World!!");
            Assert.AreEqual(expected, actual);
        }
    }
}
```

Each of the test cases above test both the "Encode" and "Normalize" methods in various scenarios including texts with vowels, non-vowels, number sequences, and special characters. It is recommended to add more sophisticated test cases to ensure the full functionality of your class under various possible cases.