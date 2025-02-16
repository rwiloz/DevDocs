Sure, here are some basic test cases for the extension methods above.

```csharp
using Xunit;
using System.Collections.Generic;
using System.Linq;
using G3.Core.Utils.ListExt;

namespace G3.Core.Utils.ListExt.Tests
{
    public class ListExtensionsTests
    {
        [Fact]
        public void FirstOrDefaultValue_Test()
        {
            // Arrange
            List<int> list = new List<int>{ 1, 2, 3, 4, 5 };
            int defaultValue = 0;
            Predicate<int> predicate = x => x > 3;
            Func<int, string> accessor = x => x.ToString();

            // Act
            var result = list.FirstOrDefaultValue(accessor, defaultValue, predicate);

            // Assert
            Assert.Equal("4", result);
        }

        [Fact]
        public void ConvertAll_Test()
        {
            // Arrange
            int[] arr = { 10, 20, 30, 40, 50 };
            Func<int, string> converter = x => x.ToString();

            // Act
            var result = arr.ConvertAll(converter);

            // Assert
            Assert.Equal(new string[] { "10", "20", "30", "40", "50" }, result);
        }

        [Fact]
        public void DistinctBy_Test()
        {
            // Arrange
            var list = new List<string> { "one", "two", "two", "three", "three", "three" };
            Func<string, int> keySelector = s => s.Length;

            // Act
            var distinct = list.DistinctBy(keySelector);

            // Assert
            Assert.Equal(new string[] { "one", "two", "three" }, distinct);
        }

        [Fact]
        public void IsNullOrEmpty_Test()
        {
            // Arrange
            IEnumerable<int> emptyList = new List<int>();
            IEnumerable<int> nullList = null;
            IEnumerable<int> list = new List<int> { 1, 2, 3 };

            // Act & Assert
            Assert.True(emptyList.IsNullOrEmpty());
            Assert.True(nullList.IsNullOrEmpty());
            Assert.False(list.IsNullOrEmpty());
        }
    }
}
```

These tests use the `xUnit` testing framework. Make sure to verify all edge cases and other scenarios for your extension methods.