# Class: CompareUtil

This class `CompareUtil` acts as a utility class within the `G3.Core.Utils.DataType` namespace. It provides static methods for the comparison of different data types in C#.

## Method: CompareObjectInt(object value1, object value2)

This static method takes two object parameters `value1` and `value2`, and compares them. It first checks if either value is not null and if so, it casts the object to an integer. It then compares these two optional integers and returns a boolean indicating if they are equal.

## Method: CompareSafeEquals(byte[] strA, byte[] strB)

This static method compares two byte arrays `strA` and `strB` for equality. It first checks if the lengths of the two byte arrays are equal and if not, it returns false. It then iterates through each pair of bytes in both arrays. If it finds a pair that is not equal, it returns false. If it finishes iterating through the arrays without finding a pair that is not equal, it returns true.

## Method: ValueInRange(decimal? minValue, decimal? maxValue, decimal compareValue)

This static method checks if a decimal value `compareValue` is in a specified range. The range is defined by a minimum value `minValue` and a maximum value `maxValue`, each of which may or may not have a value (as indicated by their status as nullable decimals). If `compareValue` is greater than or equal to `minValue` and less than or equal to `maxValue` (if they have values), or if `compareValue` is in between `minValue` and `maxValue` (if they both have values), the function returns true; otherwise, it returns false.