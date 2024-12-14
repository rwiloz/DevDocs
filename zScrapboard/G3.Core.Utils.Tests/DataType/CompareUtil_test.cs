Here are the test cases:

```csharp
using G3.Core.Utils.DataType;
using System;
using Xunit;

namespace G3.Tests
{
    public class CompareUtilTests
    {
        [Fact]
        public void CompareObjectInt_WhenValuesAreEqual_ReturnsTrue()
        {
            int a = 5;
            int b = 5;
            var result = CompareUtil.CompareObjectInt(a, b);
            Assert.True(result);
        }

        [Fact]
        public void CompareObjectInt_WhenValuesAreNotEqual_ReturnsFalse()
        {
            int a = 5;
            int b = 10;
            var result = CompareUtil.CompareObjectInt(a, b);
            Assert.False(result);
        }

        [Fact]
        public void CompareSafeEquals_WhenByteArraysAreEqual_ReturnsTrue()
        {
            byte[] arr1 = new byte[]{1, 2, 3};
            byte[] arr2 = new byte[]{1, 2, 3};
            var result = CompareUtil.CompareSafeEquals(arr1, arr2);
            Assert.True(result);
        }

        [Fact]
        public void CompareSafeEquals_WhenByteArraysAreNotEqual_ReturnsFalse()
        {
            byte[] arr1 = new byte[]{1, 2, 3};
            byte[] arr2 = new byte[]{1, 2, 4};
            var result = CompareUtil.CompareSafeEquals(arr1, arr2);
            Assert.False(result);
        }

        [Fact]
        public void ValueInRange_ValueIsInRange_ReturnsTrue()
        {
            decimal? minValue = 1;
            decimal? maxValue = 5;
            decimal compareValue = 3;
            var result = CompareUtil.ValueInRange(minValue, maxValue, compareValue);
            Assert.True(result);
        }

        [Fact]
        public void ValueInRange_ValueIsNotInRange_ReturnsFalse()
        {
            decimal? minValue = 1;
            decimal? maxValue = 5;
            decimal compareValue = 6;
            var result = CompareUtil.ValueInRange(minValue, maxValue, compareValue);
            Assert.False(result);
        }
    }
}
```
In these tests, I am using Xunit framework for the unit tests. Each method is tested with both positive cases (where the condition should be met and the method should return `true`) and negative cases (where the condition should not be met and the method should return `false`).