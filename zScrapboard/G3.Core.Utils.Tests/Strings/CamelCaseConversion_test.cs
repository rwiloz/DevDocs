Here are some possible unit test cases you could write to test the `CamelToTitleCase`, `CamelToTitleCase` with acronyms, `CapitaliseFirstCharacterSentence`, `CapitaliseFirstCharacter` and `LowerFirstCharacter` functions in the `CamelCaseConversion` class:

```C#
[TestClass]
public class CamelCaseConversionTests
{
    [TestMethod]
    public void Test_CamelToTitleCase()
    {
        // Arrange
        string input = "camelCaseText";
        string expected = "Camel Case Text";
        
        // Act
        string result = CamelCaseConversion.CamelToTitleCase(input);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_CamelToTitleCase_WithAcronyms()
    {
        // Arrange
        string input = "HTTPError";
        string[] acronyms = new string[] { "HTTP", "Error" };
        string expected = "HTTP Error";
        
        // Act
        string result = CamelCaseConversion.CamelToTitleCase(input, acronyms);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_CapitaliseFirstCharacterSentence()
    {
        // Arrange
        string input = "a test sentence";
        string expected = "A Test Sentence";
        
        // Act
        string result = CamelCaseConversion.CapitaliseFirstCharacterSentence(input);
        
        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_CapitaliseFirstCharacter()
    {
        // Arrange
        string input = "word";
        string expected = "Word";
        
        // Act
        string result = CamelCaseConversion.CapitaliseFirstCharacter(input);
        
        // Assert
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void Test_LowerFirstCharacter()
    {
        // Arrange
        string input = "Word";
        string expected = "word";
        
        // Act
        string result = CamelCaseConversion.LowerFirstCharacter(input);
        
        // Assert
        Assert.AreEqual(expected, result);
    }
}
```
Remember to import the `Microsoft.VisualStudio.TestTools.UnitTesting` namespace at the top of your source file to be able to use the `TestClass` and `TestMethod` attributes.