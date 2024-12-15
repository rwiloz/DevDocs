# StringUtils Class

The `StringUtils` class is a utility class that provides a set of static extension methods to perform various operations on strings such as comparison, checking for null or empty, encoding and decoding, adding and removing items from array, calculating similarity, encoding and decoding to base64, truncation, checking if a string is numeric, formatting, and removal of characters.

## Class Methods
Here are the provided class methods:

1. `Same(string,string)`: Determines if two strings are the same, ignoring case.
2. `SameAnyOf(string, string[])`: Determines if a string is included in a given string array, ignoring case.
3. `SameAnyOf(string, string)`: Determines if a string is included in a comma-separated values of a given string, ignoring case.
4. `HasValue(string)`: Checks if a string has any value, opposite of `IsNullOrEmpty(string)`.
5. `EncodeText(string)`: Encodes a string to ASCII.
6. `IsDigits(string)`: Determines if a string contains only digit characters (0-9).
7. `IsDigitsOrPlus(string)`: Determines if a string contains only digit characters (0-9) or a plus.
8. `IsDecimal(string)`: Determines if a string can be considered a decimal number.
9. `IsDecimalOrColon(string)`: Validates whether a string is a decimal and/or contains a colon.
10. `IsAscii(string)`: Checks if a string only contains ASCII characters.
11. `DecodeText(string)`: Decodes an ASCII string back to a regular string.
12. `AddIfNotExists(List<string>, string)`: Adds a new item to a list if it doesn't exist.
13. `Add(string[], string)`: Adds a new item to a string array if it doesn't exist.
14. `Remove(string[], string)`: Removes an existing item from a string array.
15. `SameCalcPercent(string, string)`: Calculates the percentage of similarity between two strings.
16. `SameCalcPercent2(string, string, bool)`: Calculates the percentage of similarity between two strings using Levenshtein distance algorithm, can ignore case.
17. `SameAlmost(string, string, int)`: Determines if two strings are almost the same using a specified percentage of similarity.
18. `SameAlmost2(string, string, int, bool)`: Determines if two strings are almost the same using a specified percentage of similarity and can ignore case.
19. `Base64Encode(string)`: Encodes a string to a base64 string.
20. `Base64Decode(string)`: Decodes a base64 string back to a regular string.
21. `IsBase64(string)`: Determines if a string is a valid base64 string.
22. `Truncate(string, int)`: Truncates a string to a specified length.
23. `IsNumeric(string)`: Checks if a string is numeric (integer).
24. `IsNullOrEmpty(string)`: Extension version of string.IsNullOrEmpty.
25. `NullIfEmpty(string)`: Returns null if a string is empty or returns the string itself if it is not.
26. `NumericCharactersOnly(string, string)`: Removes non-numeric characters from a string.
27. `DecimalCharactersOnly(string)`: Removes non-decimal characters from a string.
28. `AlphaCharactersOnly(string)`: Removes non-alphabetic characters from a string.
29. `AlphaNumericCharactersOnly(string)`: Removes non-alphanumeric characters from a string.
30. `FormatWith(string, object[])` and `FormatWith(string, IFormatProvider, object[])`: Mimics string format.
31. `EncodeTo64(string)`: Encodes a string to a base64 string.
32. `RemoveCharacters(string, string, string, bool, bool)`: Removes a specified set of characters from a string and replaces them with a specified new value.
33. `Replace(string, string, string, bool)`: Replaces a specified old value with a new value in a string, can be case-insensitive.
34. `Eq(string, string, StringComparison)`: Compares two strings using a specified string comparison type.
35. `ContainsString(string, string, StringComparison)`: Determines if a string contains a specified substring.
36. `ContainsAnyString(string, string[])`: Determines if a string contains any string from a list of strings.
37. `EqToEnum<TEnum>(string, TEnum)`: Compares a string with an enumeration using the enumeration's string representation.
38. `EqToOneOf(string, string[])`: Determines if a string equals to one of a list of strings.
39. `PascalCase(string, bool)`: Converts a string to PascalCase.
40. `NameCase(string)`: Formats a name to the correct case.
41. `MergeSentence(IEnumerable<string>, string, string, string)`: Combines a list of strings to a single string.
42. `Merge(IEnumerable<string>, string, string, string, string, bool, string)`: Combines a list of strings to a single formatted string.
43. `MergeWithStyle(IEnumerable<string>, string, string)`: Combines a list of strings to a single string using a separator for pairs and an alternative separator for the last pair.
44. `MergeToString<T>(IEnumerable<T>, Func<T, string>, string, string, string, string, bool)`: Combines a list of items using a string reader function to a single formatted string.