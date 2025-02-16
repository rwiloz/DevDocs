---
title: "StringTitle Utility in C#"
date: 2023-10-10
description: "A utility for converting strings to title case in C#."
---

# StringTitle Utility

The `StringTitle` utility provides a method to convert a given string into title case. This operation capitalizes the first letter of each word while converting other letters to lowercase, with specific rules for handling prefixes like "Mc" and "Mac" as well as punctuation.

## Namespace

```csharp
G3.Core.Utils.Strings
```

## Class

### `StringTitle`

This class is static and cannot be instantiated. It includes an extension method for the `string` type to facilitate title case conversion.

## Method

### `TitleCase`

```csharp
public static string TitleCase(this string value)
```

#### Parameters

- `value` (string): The input string to convert into title case.

#### Returns

- `string`: The converted string in title case format. If the input is `null`, it returns `null`.

#### Description

The `TitleCase` method processes the input string to transform it into title case. It uses various rules to determine when to capitalize a character and attempts to handle special prefixes and punctuation gracefully.

#### Process

1. Checks if the input `value` is `null`. If so, returns `null`.
2. Iterates over each character in the input string, converting it to uppercase if it's the first character of a word or lowercase otherwise.
3. Sets the subsequent character to uppercase if the current character is a space or other defined punctuation (e.g., parentheses, hyphen, etc.).
4. Specifically treats substrings with "Mc" and "Mac" to maintain traditional capitalization at the start of these prefixes.
5. Cleans up the result by replacing specific contractions like `'S` and trims the final string.

### Sample Usage

```csharp
using G3.Core.Utils.Strings;

class Program
{
    static void Main()
    {
        string title = "this is an example string";
        string result = title.TitleCase();
        Console.WriteLine(result);  // Outputs: "This Is an Example String"
    }
}
```

## Considerations

- The implementation uses a `StringBuilder` to construct the result efficiently.
- The behavior when encountering digits may capitalize characters that follow.

## Dependencies

Make sure to include the following namespaces to access `StringTitle`:

```csharp
using System;
using System.Text;
```
