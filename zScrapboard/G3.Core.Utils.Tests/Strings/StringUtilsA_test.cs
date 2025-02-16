Here are some test cases for the utils you have in the application:

```csharp
using NUnit.Framework;

[TestFixture]
public class StringUtilsTests
{
    [Test]
    public void Test_Same()
    {
        Assert.IsTrue(StringUtils.Same("test", "test"));
        Assert.IsFalse(StringUtils.Same("test", "TEST"));
        Assert.IsFalse(StringUtils.Same("test", "other"));
        Assert.IsTrue(StringUtils.Same(null, null));
        Assert.IsFalse(StringUtils.Same(null, "test"));
        Assert.IsFalse(StringUtils.Same("test", null));
    }

    [Test]
    public void Test_SameAnyOf()
    {
        Assert.IsTrue(StringUtils.SameAnyOf("test", new string[] { "test", "other" }));
        Assert.IsFalse(StringUtils.SameAnyOf("not in list", new string[] { "test", "other" }));
        Assert.IsTrue(StringUtils.SameAnyOf(null, new string[] { null, "other" }));
        Assert.IsFalse(StringUtils.SameAnyOf("not in list", null));
    }

    [Test]
    public void Test_HasValue()
    {
        Assert.IsTrue(StringUtils.HasValue("test"));
        Assert.IsFalse(StringUtils.HasValue(null));
        Assert.IsFalse(StringUtils.HasValue(""));
    }

    [Test]
    public void Test_EncodeText()
    {
        Assert.AreEqual("test", StringUtils.EncodeText("test"));
    }

    [Test]
    public void Test_IsDigits()
    {
        Assert.IsTrue(StringUtils.IsDigits("1234567890"));
        Assert.IsFalse(StringUtils.IsDigits("1234567890a"));
    }

    [Test]
    public void Test_IsDigitsOrPlus()
    {
        Assert.IsTrue(StringUtils.IsDigitsOrPlus("1234567890+"));
        Assert.IsFalse(StringUtils.IsDigitsOrPlus("1234567890+a"));
    }

    [Test]
    public void Test_IsDecimal()
    {
        Assert.IsTrue(StringUtils.IsDecimal("1234567890.-"));
        Assert.IsFalse(StringUtils.IsDecimal("1234567890.a-"));
    }

    [Test]
    public void Test_IsDecimalOrColon()
    {
        Assert.IsTrue(StringUtils.IsDecimalOrColon("1234567890.:-[]"));
        Assert.IsFalse(StringUtils.IsDecimalOrColon("1234567890.a-[]"));
    }

    [Test]
    public void Test_IsAscii()
    {
        Assert.IsTrue(StringUtils.IsAscii("test"));
        Assert.IsFalse(StringUtils.IsAscii("tést"));
    }
}
```

These test cases provide coverage for the following methods in the StringUtils class:
- Same
- SameAnyOf
- HasValue
- EncodeText
- IsDigits
- IsDigitsOrPlus
- IsDecimal
- IsDecimalOrColon
- IsAscii

You should add similar test coverage for the other methods in your StringUtils class.