Given the extensive implementation of the `StringUtils` class with many static functions, below are some example test cases.

```C#
[TestFixture]
public class StringUtilsTests
{
    [TestCase("Hello", 1, '*', "****o")]
    [TestCase("Testing", 3, '#', "####ing")]
    public void ToMaskedValue_ShoulWork(string input, int leftVisible, char maskSymbol, string expected)
    {
        var result = StringUtils.ToMaskedValue(input, leftVisible, maskSymbol);
        Assert.AreEqual(expected, result);
    }
    
    [TestCase(null, false)]
    [TestCase("", false)]
    [TestCase("Hello", false)]
    [TestCase("Hello, World!", true)]
    public void SplitAndContains_ShoulWork(string input, bool expected)
    {
        var result = StringUtils.SplitAndContains(input, ",", "World!");
        Assert.AreEqual(expected, result);
    }

    [TestCase("abc", 2, "ab")]
    public void MaxLength_ShoulWork(string input, int maxLength, string expected)
    {
        var result = StringUtils.MaxLength(input, maxLength);
        Assert.AreEqual(expected, result);
    }

    [TestCase("initials of words", "IOW")]
    public void GetInitials_ShoulWork(string input, string expected)
    {
        var result = StringUtils.GetInitials(input);
        Assert.AreEqual(expected, result);
    }

    [TestCase("strip last character", 'r', "strip last characte")]
    public void StripLastChar_ShoulWork(string input, char separator, string expected)
    {
        var result = StringUtils.StripLastChar(input, separator);
        Assert.AreEqual(expected, result);
    }

    // Continue with testing other methods...
}
```

This is pretty basic tests, for a complete testing, different edge cases, different inputs need to be provided. For example:
* Null, empty and whitespace strings.
* Single length strings.
* String length longer than what needs to be masked.
* Special characters in strings.
* Invalid separator character.
* Different cultures for methods dependent on culture sensitivity. etc.