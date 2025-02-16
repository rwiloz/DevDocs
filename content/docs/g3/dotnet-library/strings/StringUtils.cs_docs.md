---
title: "String Utils"
description: ""
summary: ""
date: 2023-09-07T16:12:37+02:00
lastmod: 2023-09-07T16:12:37+02:00
draft: false
weight: 900
toc: true
sidebar:
  collapsed: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

This is a module for working with string data types. 

It includes a class named `StringUtils` that provides static methods including: 

1. `Same` : Compares two strings for equality, ignoring case.
2. `SameAnyOf` : Checks if a string is equal to any string in an array or a comma-separated list, ignoring case.
3. `HasValue` : Checks if a string is not null or empty.
4. `EncodeText` and `DecodeText` : Methods for encoding and decoding strings using ASCII and a custom encoding string `CEncodeStr`.
5. `IsDigits`, `IsDigitsOrPlus`, `IsDecimal`, and `IsDecimalOrColon` : Methods for validating if a string contains only digit characters and/or specific other characters.
6. `IsAscii` : Checks if a string only contains ASCII characters.
7. `AddIfNotExists`, `Add`, and `Remove` : Work with lists or arrays of strings, adding or removing items as needed.
8. `SameCalcPercent` and `SameCalcPercent2` : Methods for calculating the percent similarity of two strings.
9. `SameAlmost` and `SameAlmost2` : Check if two strings are approximately the same based on a percentage threshold.
10. `Base64Encode` and `Base64Decode` : Methods for Base64 encoding and decoding strings.
11. `IsBase64` : Checks if a string is a valid Base64-encoded string.
12. `Truncate`: Truncates a string to a specified length.
13. `IsNumeric`: Checks if a string is numeric.
14. `IsNullOrEmpty`: Checks if a string is null or empty.
15. `NullIfEmpty`: Returns null if a string is empty.
16. `NumericCharactersOnly` and `DecimalCharactersOnly`: Ensures a string contains only numeric or decimal characters.
17. `AlphaCharactersOnly` and `AlphaNumericCharactersOnly`: Ensures a string contains only alphabet or alphanumeric characters.

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
1. `ToMaskedValue`: This method obscures a part of a string, leaving only the last few characters visible. This is useful for masking sensitive data like password or card number.
2. `MaskMobile` and `MaskMobileAu`: These methods mask mobile numbers while leaving the last three characters visible. The `MaskMobileAu` method is specifically designed for Australian mobile numbers.
3. `MaskEmail`: This method obscures a part of an email address, while leaving the domain and the last few characters of the local part visible. 
4. `GetString` and `GetStringDefault`: These methods return the input string, or a default string if the input is null or empty.
5. `GetTrimString`: This method trims the input string.
6. `MaxLength`: This method returns a substring with a maximum length.
7. `GetAsciiString` and `GetAsciiTrimString`: These methods convert a Unicode string into an ASCII-encoded string, replacing non-ASCII characters with a specified replacement string.
8. `ToFriendlyString`: This method converts a KeyValuePair to a friendly string representation.
9. `AsEnum`: This method attempts to parse a string into an enumeration value.
10. `GetInitials`: This method gets the initial characters for each word in a string.
11. `ShuffleAndDraw`: These methods offer a way to generate randomized strings.
12. `SplitAndContains`: This method splits a string by a specified splitter and checks if a particular element exists in the split parts.
13. `FormatNumber`: This method formats a number with a specific format by replacing `#` in the format with the number's digits.
14. `StripLastChar` and `RemoveLastCharIs`: These methods remove the last character in a string if it matches a specified character.
15. `ListToString` and `StringToList`: These methods convert lists of strings to a string separated by a specified character, and vice versa.
16. `ReplaceSpecialChars`: This method replaces specified special characters with their corresponding HTML entities.
17. `RemoveCardNumbers`: This method removes card numbers from a string by replacing parts of the numbers with 'X'.
18. `EncodeNonAsciiCharacters` and `DecodeEncodedNonAsciiCharacters`: These methods encode and decode non-ASCII characters in a string.

The `StringUtils` class is located in the `G3.Core.Utils.Strings` namespace.