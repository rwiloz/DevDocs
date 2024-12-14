In order to test `InterfaceJsonConverter`, we're mainly concerned about testing the `ReadJson()` method as other methods are simple to test or not meant to be overridden.

Here is a simple test case, Assuming you are using MSTest and Moq:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.Linq;

namespace G3.Core.Utils.JsonExt.Tests
{
    [TestClass]
    public class InterfaceJsonConverterTests
    {
        private InterfaceJsonConverter converter;

        [TestInitialize]
        public void SetUp()
        {
            converter = new InterfaceJsonConverter(new[] { typeof(IMyInterface) });
        }

        [TestMethod]
        public void ReadJson_ShouldReturnProperObject()
        {
            // Arrange
            var jsonObject = JsonConvert.DeserializeObject<ExpandoObject>("{\"Prop\":\"value\"}");
            var jsonReader = new JsonTextReader(new System.IO.StringReader(jsonObject.ToString()));
            var serializer = new JsonSerializer();

            // Act
            var result = converter.ReadJson(jsonReader, typeof(IMyInterface), null, serializer);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IMyInterface));
            var castedResult = result as IMyInterface;
            Assert.AreEqual("value", castedResult.Prop);
        }
    }

    public interface IMyInterface
    {
        string Prop { get; set; }
    }
}
```
This test case ensures that the `ReadJson` method correctly constructs an object of an interface and populates its property properly.

You should add more tests to cover negative scenarios, tests with different json formats and with different interface types. You may also want to add tests for other methods like `CanConvert`.