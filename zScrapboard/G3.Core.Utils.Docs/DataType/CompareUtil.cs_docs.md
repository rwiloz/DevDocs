---
title: "CompareUtil Class Documentation"
date: 2023-10-09
description: "Documentation for the CompareUtil class in G3.Core.Utils.DataType namespace"
draft: false
---

# CompareUtil Class

The `CompareUtil` class provides utility methods for comparing different data types such as objects, byte arrays, and decimal values. It is part of the `G3.Core.Utils.DataType` namespace.

## Methods

### CompareObjectInt

```csharp
public static bool CompareObjectInt(object value1, object value2)
```

Compares two `object` instances that are expected to contain `int` values. It returns `true` if both objects are non-null and their integer values are equal, otherwise returns `false`.

- **Parameters:**
  - `value1`: The first object to compare, expected to be an integer or null.
  - `value2`: The second object to compare, expected to be an integer or null.
  
- **Returns:** `bool` indicating whether the integer values of the objects are equal.

### CompareSafeEquals

```csharp
public static bool CompareSafeEquals(byte[] strA, byte[] strB)
```

Compares two byte arrays for equality. It returns `true` if the arrays have the same length and each corresponding pair of bytes is equal, otherwise returns `false`.

- **Parameters:**
  - `strA`: The first byte array to compare.
  - `strB`: The second byte array to compare.
  
- **Returns:** `bool` indicating whether the byte arrays are equal.

### ValueInRange

```csharp
public static bool ValueInRange(decimal? minValue, decimal? maxValue, decimal compareValue)
```

Checks if a given decimal value falls within a specified range defined by nullable minimum and maximum values. 

- **Parameters:**
  - `minValue`: The minimum value of the range, or null if there is no lower bound.
  - `maxValue`: The maximum value of the range, or null if there is no upper bound.
  - `compareValue`: The decimal value to compare against the range.
  
- **Returns:** `bool` indicating whether `compareValue` is within the specified range.

## Namespace

The class is included in the following namespace:

```csharp
namespace G3.Core.Utils.DataType
```

## See Also

For more information, visit the [Tech Mikael blog post on fast byte array comparison](http://techmikael.blogspot.com.au/2009/01/fast-byte-array-comparison-in-c.html).
```