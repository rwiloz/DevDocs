---
title: "JsonMask Utility Documentation"
date: 2023-10-15T12:00:00
draft: false
tags: ["C#", "Json", "Masking"]
---

# JsonMask Utility

## Overview

The `JsonMask` utility is a C# class designed to mask specific fields in a JSON string based on a given set of property paths and value patterns. It utilizes regular expressions to identify and replace sensitive information within JSON properties with a specified mask.

## Namespace

`G3.Core.Utils.JsonExt`

## Dependencies

- `Newtonsoft.Json`
- `Newtonsoft.Json.Linq`
- `System.Collections.Generic`
- `System.Linq`
- `System.Text.RegularExpressions`

## Class

### JsonMask

A static class that provides functionality to mask fields in JSON data.

#### Methods

##### JsonMaskFields

```csharp
public static string JsonMaskFields(this string json, string[] blackListPath, string[] maskValues, string mask)
```

###### Parameters

- `json`: A `string` that is the JSON to process and mask properties.
- `blackListPath`: A `string[]` array of case-insensitive property paths to identify specific fields for masking.
- `maskValues`: A `string[]` array of regex patterns to match values within the JSON.
- `mask`: A `string` specifying the mask to replace the property value with.

###### Returns

- Returns a `string` representation of the JSON with specified fields masked.

###### Exceptions

- Throws `ArgumentNullException` if `json`, `blackListPath`, or `maskValues` are `null` or empty.

##### MaskFieldsFromJToken

```csharp
private static void MaskFieldsFromJToken(JToken token, string[] blackListPath, string[] maskValues, string mask)
```

###### Parameters

- `token`: A `JToken` element from Newtonsoft.Json.Linq that represents the JSON to examine for masking.
- `blackListPath`: A `string[]` array of case-insensitive property paths.
- `maskValues`: A `string[]` array of regex patterns for values.
- `mask`: A `string` mask that will replace the identified property value.

## Example Usage

```csharp
string json = "{\"name\":\"John Doe\",\"creditCard\":\"1234-5678-9012-3456\"}";
string[] blackListPath = new string[] { "creditCard" };
string[] maskValues = new string[] { "\\d{4}-\\d{4}-\\d{4}-\\d{4}" };
string mask = "****-****-****-****";

string maskedJson = json.JsonMaskFields(blackListPath, maskValues, mask);
Console.WriteLine(maskedJson);
```

This example masks the `creditCard` field's value within the given JSON string, replacing it with `****-****-****-****`.

## Notes

- The utility relies heavily on regular expressions for pattern matching within JSON paths and values.
- Proper error handling is implemented by throwing exceptions for invalid inputs.
```