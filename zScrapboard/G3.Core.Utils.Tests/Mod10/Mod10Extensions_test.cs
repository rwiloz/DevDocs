Below are the test cases for the provided C# code.

To implement the test cases you'll need to use a unit testing framework, such as NUnit or xUnit. Below are example test cases using NUnit.

```csharp
using NUnit.Framework;
using G3.Core.Utils.Mod10;
    
[TestFixture]
public class Mod10Tests
{
    [Test]
    public void Mod10CheckDigit_ShouldReturnCorrectCheckDigit()
    {
        var result = Mod10Extensions.Mod10CheckDigit("123456789");
        Assert.AreEqual("10", result);
    }
    
    [Test]
    public void AddMod10_ShouldAddCorrectly()
    {
        var result = "123456789".AddMod10();
        Assert.AreEqual("12345678910", result);
    }
    
    [Test]
    public void Mod10Check_ShouldReturnValidForCorrectNumber()
    {
        var result = "1234567891".Mod10Check();
        Assert.IsTrue(result);
    }
    
    [Test]
    public void Mod10Check_ShouldReturnInvalidForIncorrectNumber()
    {
        var result = "123456789".Mod10Check();
        Assert.IsFalse(result);
    }

    [Test]
    public void Mod10Check_ShouldReturnInvalidForNull()
    {
        string number = null;
        var result = number.Mod10Check(); 
        Assert.IsFalse(result);
    }

    [Test]
    public void Mod10Check_ShouldReturnInvalidForEmptyString()
    {
        var result = "".Mod10Check(); 
        Assert.IsFalse(result);
    }
}
```
Please note that these are basic test cases, in real world scenarios you might need to write more test cases to cover all the edge cases.
Also note that your `Mod10CheckDigit` method will always return "10" for a number that their sum%10 results exactly equal to 0, which is not valid as a check digit can't be 10.