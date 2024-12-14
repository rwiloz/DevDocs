Sure, I'll create test cases for your code. Here are some NUnit test cases for the WordDifference method:

```csharp
using NUnit.Framework;
using G3.Core.Utils.Strings;

[TestFixture]
public class ApproximateDistanceHelperTest
{
    [TestCase("hello", "hello", 0)]
    [TestCase("hello", "helli", 0.2)] 
    [TestCase("hello", "world", 1)] 
    [TestCase("asdfgh", "qwerty", 1)] 
    public void TestWordDifference(string string1, string string2, double expectedDifference)
    {
        Assert.AreEqual(expectedDifference, string1.WordDifference(string2));
    }
}
```

Here are some NUnit test cases for the Difference method:

```csharp
[TestFixture]
public class ApproximateDistanceHelperTest
{
    [TestCase("hello", "hello", true, 0)]
    [TestCase("hello", "hell", true, 0.2)]
    [TestCase("hello", "helli", false, 0.2)]
    [TestCase("hello", "helli hello", false, 0)]
    public void TestDifference(string string1, string string2, bool forbidSplit, double expectedDifference)
    {
        Assert.AreEqual(expectedDifference, string1.Difference(string2, forbidSplit));
    }
}
```

These tests should help verify the accuracy of your functions. You may need to adjust the expected values depending on specifics of your Metaphone and Levenshtein distance algorithms as well as your test cases' inputs.
  
Please note that you would need to install NUnit Framework to your project (which can be done via NuGet Packages) to use these tests.