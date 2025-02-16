To test your JsonArrayConverter, you would ideally want to check that it can properly handle and convert List<T> objects.

Here is an example NUnit test case:

```csharp
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class JsonArrayConverterTests
{
    [Test]
    public void CanConvert_ShouldReturnTrue_ForListOfTType()
    {
        var converter = new JsonArrayConverter<string>();
        Assert.IsTrue(converter.CanConvert(typeof(List<string>)));
    }

    [Test]
    public void CanConvert_ShouldReturnFalse_ForNotListOfTType()
    {
        var converter = new JsonArrayConverter<string>();
        Assert.IsFalse(converter.CanConvert(typeof(string)));
    }
    
    [Test]
    public void CanWrite_ShouldReturnFalse()
    {
        var converter = new JsonArrayConverter<string>();
        Assert.IsFalse(converter.CanWrite);
    }

    [Test]
    public void WriteJson_ShouldThrowNotImplementedException()
    {
        var converter = new JsonArrayConverter<string>();
        Assert.Throws<NotImplementedException>(() => converter.WriteJson(null, null, null));
    }

    [Test]
    public void ReadJson_ShouldReturnListOfT_ForJsonArrayString()
    {
        var converter = new JsonArrayConverter<string>();
        var json = new JsonTextReader(new StringReader("[\"Test\"]"));
        var result = converter.ReadJson(json, typeof(List<string>), null, new JsonSerializer());
        Assert.IsTrue(result is List<string>);
    }

    [Test]
    public void ReadJson_ShouldReturnListOfT_WithOneElement_ForJsonStringValue()
    {
        var converter = new JsonArrayConverter<string>();
        var json = new JsonTextReader(new StringReader("\"Test\""));
        var result = converter.ReadJson(json, typeof(string), null, new JsonSerializer());
        Assert.IsTrue(result is List<string> && ((List<string>)result).Count == 1);
    }
}
```

These test cases cover the general functionality of your JsonArrayConverter class. They test that CanConvert returns correct values based on input, that ReadJson can handle JSON array strings and single value strings, and that WriteJson throws an exception as it is not implemented.