Sure, I will create some basic unit tests for these methods. We can create more complex test scenarios as needed. Here are few basic tests:

```csharp
using Xunit;
using System.Collections.Generic;
using static G3.Core.Utils.Dictionaries.DictionaryHelpers;

public class DictionaryHelpersTests
{
    [Fact]
    public void TestToDictionaryListWithOneParameter()
    {
        // Arrange
        IEnumerable<int> originalList = new List<int> { 1, 2, 3, 4 };
        Func<int, int> keyDelegate = x => x;

        // Act
        var result = originalList.ToDictionaryList(keyDelegate, null);

        // Assert
        Assert.Equal(4, result.Count);
    }

    [Fact]
    public void TestToDictionaryValueWithOneParameter()
    {
        // Arrange
        IEnumerable<int> originalList = new List<int> { 1, 2, 3, 4 };
        Func<int, int> keyDelegate = x => x;

        // Act
        var result = originalList.ToDictionaryValue(keyDelegate, true, null);

        // Assert
        Assert.Equal(4, result.Count);
    }

    [Fact]
    public void TestCount()
    {
        // Arrange
        IEnumerable list = new List<int> { 1, 2, 3, 4 };

        // Act
        var result = list.Count();

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void TestIsEmpty()
    {
        // Arrange
        IEnumerable list = new List<int>() { };

        // Act
        var result = list.IsEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void TestGet()
    {
        // Arrange
        var dict = new Dictionary<int, int> { { 1, 10 }, { 2, 20 } };

        // Act
        var result = dict.Get(2, 0);

        // Assert
        Assert.Equal(20, result);
    }
    
    [Fact]
    public void TestToDictionaryIgnoreCase()
    {
        // Arrange
        var dict = new Dictionary<string, int> { { "ONE", 10 }, { "TWO", 20 } };

        // Act
        var result = dict.ToDictionaryIgnoreCase();

        // Assert
        Assert.Equal(dict, result);
    }
}
```
You need to have `XUnit` NuGet packages to run these tests. You can install it with the following command in Package Manager Console:

```shell
Install-Package xunit
Install-Package xunit.runner.visualstudio
```

These tests are pretty basic and they only cover the happy path, more tests are necessary to check for edge cases and expected failures.