using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.DataType
{
    public class CompareUtil
    {
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

        //http://techmikael.blogspot.com.au/2009/01/fast-byte-array-comparison-in-c.html
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

        public static bool ValueInRange(decimal? minValue, decimal? maxValue, decimal compareValue)
        {
            return ((!minValue.HasValue || (compareValue >= minValue)) && (!maxValue.HasValue || (compareValue <= maxValue.GetValueOrDefault())));
        }
    }
}
