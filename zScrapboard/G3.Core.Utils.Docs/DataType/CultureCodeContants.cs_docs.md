---
title: CultureCodeConstants Utility Class
description: Documentation for the CultureCodeConstants class in the G3.Core.Utils.DataType namespace.
---

# CultureCodeConstants Utility Class

The `CultureCodeConstants` class is a static utility class within the `G3.Core.Utils.DataType` namespace. It provides functionality related to culture codes, particularly focusing on different date formats and parsing based on cultural settings.

## Namespace

```csharp
G3.Core.Utils.DataType
```

## Class: CultureCodeConstants

### Summary

The `CultureCodeConstants` class provides constants and operations for handling culture-specific string operations. It includes methods for checking U.S.-based cultures and formatting dates accordingly.

### Constants

- **enAU**: `string`  
  Represents the culture code for Australian English ("en-AU").

- **enUS**: `string`  
  Represents the culture code for U.S. English ("en-US").

- **enSP**: `string`  
  Represents the culture code for U.S. Spanish ("es-US").

### Methods

#### IsUS

```csharp
public static bool IsUS(string culture)
```

- **Description**: Determines if the given culture code is considered a U.S.-based culture.
- **Parameters**:  
  - `culture` (`string`): The culture code to evaluate.
- **Returns**:  
  `bool`: `true` if the culture is "en-US" or "es-US"; otherwise, `false`.

#### GetDateFormat

```csharp
public static string GetDateFormat(string culture)
```

- **Description**: Returns the date format string based on the provided culture code.
- **Parameters**:  
  - `culture` (`string`): The culture code to evaluate.
- **Returns**:  
  `string`: The date format string. Returns "MM/dd/yyyy" for U.S.-based cultures, and "dd/MM/yyyy" for others.

#### GetDateTime

```csharp
public static DateTime? GetDateTime(string cultureCode, string date)
```

- **Description**: Parses a date string into a `DateTime` object based on the provided culture code.
- **Parameters**:  
  - `cultureCode` (`string`): The culture code that dictates the parsing rules.
  - `date` (`string`): The date string to parse.
- **Returns**:  
  `Nullable<DateTime>`: A `DateTime` object if the parsing is successful and the date is within the valid range (1900-2099), otherwise `null`.

### Remarks

- The methods in this class assume date strings are in the format "dd/MM/yyyy" or "MM/dd/yyyy", depending on the culture.
- The `GetDateTime` method ensures the parsed date is within a certain range (January 1, 1900 - December 31, 2099) before returning a value.

## Example

Here's a brief example on how to use the `GetDateTime` method to parse a date:

```csharp
DateTime? parsedDate = CultureCodeConstants.GetDateTime("en-US", "03/17/2025");
if (parsedDate.HasValue)
{
    Console.WriteLine($"Parsed Date: {parsedDate.Value.ToString()}");
}
else
{
    Console.WriteLine("Invalid date format or date out of range.");
}
```
```