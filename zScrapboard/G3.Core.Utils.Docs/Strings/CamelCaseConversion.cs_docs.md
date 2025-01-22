---
title: "CamelCaseConversion Utility Class"
date: 2023-10-04
description: "Documentation for the CamelCaseConversion utility class in the G3.Core.Utils.Strings namespace."
---

# CamelCaseConversion Utility Class

The `CamelCaseConversion` class provides a set of static methods for converting camel case strings to title case and manipulating string capitalization. It resides in the `G3.Core.Utils.Strings` namespace. This document details each method, its purpose, parameters, return values, and usage.

## Methods

### CamelToTitleCase(String)

```csharp
public static string CamelToTitleCase(this string text)
```

Converts a camel case string to title case by inserting spaces before capital letters. Handles sequences of uppercase letters by intelligently determining word boundaries.

- **Parameters**: 
  - `text`: A string in camel case format.
- **Returns**: 
  - A string converted to title case.

### CamelToTitleCase(String, String[])

```csharp
public static string CamelToTitleCase(this string text, string[] acronyms)
```

Converts a camel case string to title case while ensuring specified acronyms remain fully capitalized.

- **Parameters**: 
  - `text`: A string in camel case format.
  - `acronyms`: An array of strings that specify which segments of the text should remain capitalized.
- **Returns**: 
  - A string converted to title case with specified acronyms capitalized.

### CapitaliseFirstCharacterSentence(String)

```csharp
public static string CapitaliseFirstCharacterSentence(this string sentence)
```

Capitalizes the first character of each word in a sentence, ensuring appropriate spacing.

- **Parameters**: 
  - `sentence`: A sentence where each word's first character needs capitalization.
- **Returns**: 
  - A string with each word's first character capitalized.

### CapitaliseFirstCharacter(String)

```csharp
public static string CapitaliseFirstCharacter(this string text)
```

Capitalizes the first character of the given string while making the rest of the string lowercase.

- **Parameters**: 
  - `text`: A string which requires its first character to be capitalized.
- **Returns**: 
  - A string with its first character capitalized.

### LowerFirstCharacter(String)

```csharp
public static string LowerFirstCharacter(string text)
```

Converts the first character of the string to lowercase.

- **Parameters**: 
  - `text`: A string whose first character needs to be converted to lowercase.
- **Returns**: 
  - A string with its first character in lowercase.

## Usage

The methods of the `CamelCaseConversion` class are extension methods for the `string` type. They facilitate string manipulation tasks commonly needed for text formatting, especially in converting camel case to a human-readable format.

### Example

```csharp
string camelCaseText = "exampleCamelCaseString";
string titleCaseText = camelCaseText.CamelToTitleCase();
// Output: "Example Camel Case String"
```

Use these methods to handle text in applications where readability and capitalization are important, such as in user interfaces or data display contexts.
```