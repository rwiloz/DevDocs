Here's your code with inline XML summary comments:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.DataType
{
    /// <summary>
    /// Utility class to provide comparison functions.
    /// </summary>
    public class CompareUtil
    {
        /// <summary>
        /// Compare two objects after casting them as integers.
        /// </summary>
        /// <param name="value1">First object to compare.</param>
        /// <param name="value2">Second object to compare.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public static bool CompareObjectInt(object value1, object value2)
        {
            var nullableValue1 = new int?();
            var nullableValue2 = new int?();
            if (value1 != null)
            {
                nullableValue1 = (int)value1;
            }

            if (value2 != null)
            {
                nullableValue2 = (int)value2;
            }

            return nullableValue1 == nullableValue2;
        }

        /// <summary>
        /// Compares two byte arrays for equality.
        /// </summary>
        /// <param name="strA">First byte array to compare.</param>
        /// <param name="strB">Second byte array to compare.</param>
        /// <returns>True if the arrays are equal, false otherwise.</returns>
        /// <remarks>This function is optimized for speed. See http://techmikael.blogspot.com.au/2009/01/fast-byte-array-comparison-in-c.html for more information.</remarks>
        public static bool CompareSafeEquals(byte[] strA, byte[] strB)
        {
            int length = strA.Length;
            if (length != strB.Length)
            {
                return false;
            }
            for (int i = 0; i < length; i++)
            {
                if (strA[i] != strB[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Determines if a specified value falls within a defined range.
        /// </summary>
        /// <param name="minValue">The minimum value of the range, inclusive.</param>
        /// <param name="maxValue">The maximum value of the range, inclusive.</param>
        /// <param name="compareValue">The value to be compared.</param>
        /// <returns>True if the compareValue is within range, false otherwise.</returns>
        public static bool ValueInRange(decimal? minValue, decimal? maxValue, decimal compareValue)
        {
            return ((!minValue.HasValue || (compareValue >= minValue)) && (!maxValue.HasValue || (compareValue <= maxValue.GetValueOrDefault())));
        }
    }
}
```
This way, all your methods have a descriptive summary of what they do, and all parameters are explained. Notice how the `<returns>` element describes the return value of a method and `<param>` element describes a parameter, `<remarks>` element is also used to add additional information to the XML documentation.