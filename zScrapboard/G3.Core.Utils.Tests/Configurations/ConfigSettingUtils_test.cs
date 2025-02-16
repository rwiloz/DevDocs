To create test cases in C#, usually we leverage a unit testing framework like NUnit or xUnit. Here I will use NUnit for creating the test cases.

```csharp
using NUnit.Framework;
using System.Configuration;
using G3.Core.Utils.Configurations;
using Moq;

namespace G3.Tests.Utils.Configurations
{
    [TestFixture]
    public class ConfigSettingUtilsTests
    {
        private Mock<ConfigurationManager> _mockConfigManager;
        
        [SetUp]
        public void SetUp()
        {
            _mockConfigManager = new Mock<ConfigurationManager>();
        }

        [Test]
        public void GetBool_WithTrueSetting_ReturnsTrue()
        {
            // Arrange
            var setting = "TestSetting";
            _mockConfigManager.Setup(x => x.AppSettings[setting]).Returns("true");

            // Act
            var result = _mockConfigManager.Object.GetBool(setting, false);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GetBool_WithFalseSetting_ReturnsFalse()
        {
            // Arrange
            var setting = "TestSetting";
            _mockConfigManager.Setup(x => x.AppSettings[setting]).Returns("false");

            // Act
            var result = _mockConfigManager.Object.GetBool(setting, true);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GetBool_WithInvalidSetting_ReturnsDefaultValue()
        {
            // Arrange
            var setting = "InvalidSetting";
            _mockConfigManager.Setup(x => x.AppSettings[setting]).Returns((string)null);

            // Act
            var result = _mockConfigManager.Object.GetBool(setting, false);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
```

Just a note that my mock handling might not be entirely correct, because `ConfigurationManager` is a static class and mocking static entities is tricky (even considered as a design smell by some). If your `ConfigurationManager` is an instance one, just ignore my notice!