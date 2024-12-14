Below are some test cases that you can use:

```CSharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace G3.Core.Utils.JsonExt.Tests
{

    [TestClass]
    public class JsonMaskFieldsTests
    {
        [TestMethod]
        public void JsonMaskFields_BlankJson_ThrowsArgumentNullException()
        {
            // Arrange
            string json = "";

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => json.JsonMaskFields(null, null, null));
        }

        [TestMethod]
        public void JsonMaskFields_NullBlackList_ThrowsArgumentNullException()
        {
            // Arrange
            string json = "{ \"test\": \"value\" }";
            
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => json.JsonMaskFields(null, null, null));
        }

        [TestMethod]
        public void JsonMaskFields_NullMaskValues_ThrowsArgumentNullException()
        {
            // Arrange
            string json = "{ \"test\": \"value\" }";
            string[] blacklist = { "test" };

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => json.JsonMaskFields(blacklist, null, null));
        }

        [TestMethod]
        public void JsonMaskFields_ValidJson_MasksFields()
        {
            // Arrange
            string json = "{ \"password\": \"hidden\", \"email\": \"example@example.com\" }";
            string[] blacklist = { "password", "email" };
            string[] maskValues = { "\\w+" };
            string maskedValue = "****";

            // Act
            string maskedJson = json.JsonMaskFields(blacklist, maskValues, maskedValue);

            // Assert
            Assert.AreEqual("{ \"password\": \"****\", \"email\": \"****\" }", maskedJson);
        }

        [TestMethod]
        public void JsonMaskFields_ValidJson_KeepsNonMaskedFields()
        {
            // Arrange
            string json = "{ \"password\": \"hidden\", \"email\": \"example@example.com\", \"name\": \"John Doe\" }";
            string[] blacklist = { "password", "email" };
            string[] maskValues = { "\\w+" };
            string maskedValue = "****";

            // Act
            string maskedJson = json.JsonMaskFields(blacklist, maskValues, maskedValue);

            // Assert
            Assert.AreEqual("{ \"password\": \"****\", \"email\": \"****\", \"name\": \"John Doe\" }", maskedJson);
        }
    }
}
```

This set of test cases tests for exception that can be thrown when incorrect arguments are passed to the `JsonMaskFields` function. It also tests for masking the fields in the blacklist and keeping the non-blacklisted fields as is.