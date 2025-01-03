---
title: "Data Type Converters"
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

# DataTypeConverter Class

The `DataTypeConverter` class provides a bunch of static extension methods that support data conversions from `string` to different data types including `bool`, `decimal`, `double`, `int`, `long` and `Enum`. It also includes methods for removing trailing zeros from `decimal` values, determining the scale of a `decimal` type, parsing string arrays to a list of long, and converting byte arrays and strings to hexadecimal representation.

## Methods

Here are some of the methods in this class:

- `ToBoolean`: This method extends the `string` class and converts a `string` value to a `boolean`. It supports the interpretation of '1', 'Y', 'true', and 'yes' as `true`.

- `ToDecimal`: This method extends the `string` class and attempts to parse the string as a `decimal` type. If it fails, it returns zero.

- `ToNullableDecimal`: Similar to `ToDecimal`, but returns a nullable `decimal`. If the parsing fails or the input string is null or empty, it returns null.

- `ToNullableDouble`: Similar to `ToNullableDecimal`, but works with `double` type.

- `ToInt32`: Tries to parse a `string` to an `int`. If parsing fails, it will return a default value provided as input to the function or zero as default.

- `ToInt64`: Similar to `ToInt32`, but works with `long` type.

- `TryParseToInt64List`: Converts an array of Strings into a list of long integers.

- `NumberOfDecimalPlaces`: Returns the total number of decimal places in a given `decimal?` number.

- `ToString`: An overload for the `ToString()` method that presents the decimal numbers up to a given precision.

- `ToNullableInt64`: Similar to `ToInt64` but returns a nullable `long`.

- `RemoveTrailingZeros`: Provides two overloads for `decimal` and `decimal?` to remove any trailing zeros in a decimal number.

- `GetDecimalScale`: Returns the scale of a `decimal` number, i.e., the  number of digits to the right of the decimal point.

- `ToEnum`: Converts a `string` to an `Enum` value.
  
- `ToHex`: Provides two overloaded methods, one for `byte[]` and one for `string`, to convert given value to its hexadecimal representation in a string format.
