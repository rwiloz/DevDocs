---
title: "LinqExtensions Documentation"
description: "Developer documentation for the LinqExtensions utility methods."
author: "G3 Core Team"
date: "2025-01-19"
draft: false
---

# LinqExtensions

## Overview
The `LinqExtensions` class provides utility extension methods for working with LINQ operations in C#. These methods enhance the usability and efficiency of LINQ queries by adding common transformations and filtering mechanisms.

## Namespace
```csharp
namespace G3.Core.Utils.LinqExt;
```

## Extension Methods

### `FirstOrDefaultValue`
#### Description
Retrieves the first element from a collection that matches a given predicate and applies a transformation function. If no match is found, returns a specified default value.

#### Syntax
```csharp
public static TValue FirstOrDefaultValue<TItem, TValue>(
    this IEnumerable<TItem> list,
    Func<TItem, TValue> accessor,
    TValue defaultValue = default(TValue),
    Predicate<TItem> predicate = null);
```

#### Parameters
- `list`: The source collection.
- `accessor`: A function to transform the selected item.
- `defaultValue`: A default value returned if no matching item is found.
- `predicate`: (Optional) A condition that items must meet to be considered.

#### Returns
- The transformed value of the first matching item, or the default value if no match is found.

#### Example
```csharp
var numbers = new List<int> { 1, 2, 3, 4 };
var result = numbers.FirstOrDefaultValue(x => x * 2, 0, x => x > 2);
Console.WriteLine(result); // Output: 6
```

---

### `ConvertAll`
#### Description
Converts an array of one type to an array of another type using a provided converter function.

#### Syntax
```csharp
public static TTarget[] ConvertAll<TSource, TTarget>(
    this TSource[] source,
    Func<TSource, TTarget> converter);
```

#### Parameters
- `source`: The source array.
- `converter`: A function that converts each element to the target type.

#### Returns
- An array of converted elements.

#### Example
```csharp
string[] words = { "1", "2", "3" };
int[] numbers = words.ConvertAll(int.Parse);
```
