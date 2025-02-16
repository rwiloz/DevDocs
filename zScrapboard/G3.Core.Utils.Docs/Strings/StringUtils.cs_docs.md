---
title: "StringUtils: String Utilities for C#"
date: 2023-10-12
draft: false
---

# StringUtils: C# String Utility Methods

The `StringUtils` class is part of the `G3.Core.Utils.Strings` namespace, providing a collection of utility methods for string manipulation. This class includes extensions for checking string equality, encoding and decoding, masking, and other common string operations.

## Methods

### Equality and Comparison

#### `Same(this string data1, string data2)`

Checks if two strings are equal, ignoring case using the current culture.

#### `SameAnyOf(this string data1, string[] data2)`

Checks if the first string matches any string in the provided array, ignoring case.

#### `SameAnyOf(this string data1, string data2)`

Splits the second string by comma and checks if any resulting substring matches the first string, ignoring case.

#### `HasValue(this string data)`

Returns `true` if the string is not null or empty.

### Encoding and Decoding

#### `EncodeText(this string data)`

Encodes a string using a custom encoding scheme defined by a constant character map.

#### `DecodeText(this string data)`

Decodes a string encoded with the `EncodeText` method.

#### `Base64Encode(this string plainText)`

Encodes a string to Base64.

#### `Base64Decode(this string base64EncodedData)`

Decodes a Base64 encoded string.

### Character Checks

#### `IsDigits(this string data)`

Returns `true` if the string contains only numeric digits.

#### `IsDigitsOrPlus(this string data)`

Returns `true` if the string contains only numeric digits or plus signs.

#### `IsDecimal(this string data)`

Returns `true` if the string is a valid decimal number.

#### `IsDecimalOrColon(this string data)`

Returns `true` if the string is a valid decimal or IP address format.

### String Modifications

#### `AddIfNotExists(this List<string> list, string item)`

Adds an item to a list if it does not already exist in the list.

#### `Truncate(this string value, int length)`

Truncates a string to a specified length.

### Similarity Calculations

#### `SameCalcPercent(string data1, string data2)`

Calculates the similarity percentage based on character frequency between two strings.

#### `SameCalcPercent2(string data1, string data2, bool ignoreCase)`

Calculates the similarity percentage using the Levenshtein distance.

### Utility Methods

#### `IsNullOrEmpty(this string value)`

Extension method for checking if a string is null or empty.

#### `NullIfEmpty(this string value)`

Returns null if the string is empty; otherwise returns the string.

#### `NumericCharactersOnly(this string strValue, string defaultRegex)`

Removes non-numeric characters from a string.

#### `AlphaCharactersOnly(this string strValue)`

Removes non-alphabetic characters from a string.

#### `ReplaceSpecialChars(this string value)`

Replaces special characters in a string with their HTML entity equivalents.

## Example Usage

```csharp
using G3.Core.Utils.Strings;

class Program
{
    static void Main()
    {
        string example = "Hello, World!";
        bool hasValue = example.HasValue();
        string base64Encoded = example.Base64Encode();
        string truncated = example.Truncate(5);
        
        Console.WriteLine($"Has Value: {hasValue}");
        Console.WriteLine($"Base64 Encoded: {base64Encoded}");
        Console.WriteLine($"Truncated: {truncated}");
    }
}
```

These methods provide comprehensive functionality for handling strings in C#, making it easier to manipulate text data efficiently. Utilize these methods for cleaner, more maintainable code in your projects.
```

