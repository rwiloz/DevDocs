Here are some test cases using MS Test framework:

```Csharp
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G3.Core.Utils.LinqExt;
using System.Collections.Generic;

namespace G3.Core.Utils.LinqExt.Tests
{
    [TestClass]
    public class ListExtensionsTests
    {
        [TestMethod]
        public void TestFirstOrDefaultValue()
        {
            // Arrange
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            var result = list.FirstOrDefaultValue(i => i, 0, i => i > 3);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestConvertAll()
        {
            // Arrange
            int[] source = { 1, 2, 3, 4 };

            // Act
            string[] result = source.ConvertAll(i => i.ToString());

            // Assert
            CollectionAssert.AreEqual(new string[] { "1", "2", "3", "4" }, result);
        }

        [TestMethod]
        public void TestToHashSet()
        {
            // Arrange
            List<int> source = new List<int> { 1, 2, 3, 4, 2 };

            // Act
            var result = source.ToHashSet();

            // Assert
            Assert.IsInstanceOfType(result, typeof(HashSet<int>));
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3, 4 }, result.ToList());
        }

        [TestMethod]
        public void TestDistinctBy()
        {
            // Arrange
            List<string> source = new List<string> { "Chris", "Chris", "Jane", "John" };

            // Act
            var result = source.DistinctBy(s => s);

            // Assert
            CollectionAssert.AreEquivalent(new List<string> { "Chris", "Jane", "John" }, result.ToList());
        }
    }
}
```

These tests are using the MSTest testing framework and the Arrange-Act-Assert pattern (AAA pattern) widely used for writing test cases. You might need to adapt them if you're using a different testing framework or pattern.