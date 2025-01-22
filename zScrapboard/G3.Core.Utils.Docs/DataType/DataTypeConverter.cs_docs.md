+++
title = "DataTypeConverter Class"
description = "A utility class for converting between strings and various data types in C#."
date = "2023-10-31"
draft = false
toc = true
+++

# DataTypeConverter Class

The `DataTypeConverter` class provides extension methods for converting strings into various data types, such as boolean, decimal, double, integer, and long, as well as the conversion of byte arrays and strings into hexadecimal representations.

## Methods

### ToBoolean

```csharp
public static bool ToBoolean(this string value, bool defaultValue = false)
```

Converts a string to a boolean value. Returns the specified default value if the input string is null or empty.

- **Parameters:**
  - `value` (string): The input string to convert.
  - `defaultValue` (bool, optional): The default boolean value to return if the conversion fails. The default is `false`.
  
- **Returns:** 
  - `bool`: The converted boolean value.

### ToDecimal

```csharp
public static decimal ToDecimal(this string parseValue)
```

Converts a string to a decimal value. Returns 0 if the conversion fails.

- **Parameters:**
  - `parseValue` (string): The input string to convert.

- **Returns:** 
  - `decimal`: The converted decimal value.

### ToNullableDecimal

```csharp
public static decimal? ToNullableDecimal(this string parseValue)
```

Converts a string to a nullable decimal value. Returns `null` if the input is null or empty.

- **Parameters:**
  - `parseValue` (string): The input string to convert.

- **Returns:** 
  - `decimal?`: The converted nullable decimal value.

### ToNullableDouble

```csharp
public static double? ToNullableDouble(this string parseValue)
```

Converts a string to a nullable double value. Returns `null` if the input is null or empty.

- **Parameters:**
  - `parseValue` (string): The input string to convert.
  
- **Returns:** 
  - `double?`: The converted nullable double value.

### ToInt32

```csharp
public static int ToInt32(this string parseValue, int defaultValue = 0)
```

Converts a string to a 32-bit integer. Returns the specified default value if the conversion fails.

- **Parameters:**
  - `parseValue` (string): The input string to convert.
  - `defaultValue` (int, optional): The default integer value to return if the conversion fails. The default is `0`.

- **Returns:** 
  - `int`: The converted integer value.

### ToInt64

```csharp
public static long ToInt64(this string parseValue, long defaultValue = 0)
```

Converts a string to a 64-bit integer. Returns the specified default value if the conversion fails.

- **Parameters:**
  - `parseValue` (string): The input string to convert.
  - `defaultValue` (long, optional): The default long value to return if the conversion fails. The default is `0`.

- **Returns:** 
  - `long`: The converted long value.

### TryParseToInt64List

```csharp
public static IEnumerable<long> TryParseToInt64List(string[] stringList)
```

Converts an array of string values to a list of 64-bit integers. Only successfully parsed values are added to the list.

- **Parameters:**
  - `stringList` (string[]): The array of strings to convert.

- **Returns:** 
  - `IEnumerable<long>`: A list of successfully parsed 64-bit integers.

### NumberOfDecimalPlaces

```csharp
public static int NumberOfDecimalPlaces(this decimal? value)
```

Calculates the number of decimal places in a nullable decimal value.

- **Parameters:**
  - `value` (decimal?): The decimal value to analyze.

- **Returns:** 
  - `int`: The number of decimal places.

### ToString

```csharp
public static string ToString(this Decimal? decimalValue, int precision = 2)
```

Converts a nullable decimal to a string representation with specified precision.

- **Parameters:**
  - `decimalValue` (decimal?): The decimal value to convert.
  - `precision` (int, optional): The number of decimal places to include. The default is `2`.

- **Returns:** 
  - `string`: The string representation of the decimal value.

### ToNullableInt64

```csharp
public static long? ToNullableInt64(this string value)
```

Converts a string to a nullable 64-bit integer. Returns `null` if the input string is null or cannot be parsed.

- **Parameters:**
  - `value` (string): The input string to convert.

- **Returns:**
  - `long?`: The converted nullable long value.

### RemoveTrailingZeros

```csharp
public static decimal RemoveTrailingZeros(this decimal value)
```

Removes trailing zeros from a decimal value.

- **Parameters:**
  - `value` (decimal): The decimal value to process.

- **Returns:**
  - `decimal`: The decimal value without trailing zeros.

```csharp
public static decimal? RemoveTrailingZeros(this decimal? value)
```

Removes trailing zeros from a nullable decimal value.

- **Parameters:**
  - `value` (decimal?): The decimal value to process.

- **Returns:**
  - `decimal?`: The nullable decimal value without trailing zeros.

### GetDecimalScale

```csharp
public static int GetDecimalScale(this decimal value)
```

Determines the scale (number of decimal places) of a decimal value.

- **Parameters:**
  - `value` (decimal): The decimal value to analyze.

- **Returns:**
  - `int`: The number of decimal places.

### ToEnum

```csharp
public static T ToEnum<T>(this string value, T defaultValue) where T : struct
```

Converts a string to an enumeration value of type `T`. Returns the specified default value if the conversion fails.

- **Parameters:**
  - `value` (string): The input string to convert.
  - `defaultValue` (T): The default enumeration value to return if the conversion fails.

- **Returns:** 
  - `T`: The converted enumeration value.

### ToHex

```csharp
public static string ToHex(this byte[] data)
```

Converts a byte array to a hexadecimal string representation.

- **Parameters:**
  - `data` (byte[]): The byte array to convert.

- **Returns:** 
  - `string`: The hexadecimal string representation of the byte array.

```csharp
public static string ToHex(this string data)
```

Converts a string to its hexadecimal representation.

- **Parameters:**
  - `data` (string): The string to convert.

- **Returns:**
  - `string`: The hexadecimal string representation of the input string.
```