---
title: "ListExtensions Utility Methods"
date: 2023-10-05
description: "Utility methods for operating on lists and collections, implemented in C#."
draft: false
---

# ListExtensions Utility Methods

The `ListExtensions` class provides a set of extension methods that enhance the capabilities of lists and enumerable collections. These methods are implemented as static methods to be used in a fluent programming style, allowing you to perform operations directly on list or array instances.

## Methods Overview

### FirstOrDefaultValue

```csharp
public static TValue FirstOrDefaultValue<TItem, TValue>(this IEnumerable<TItem> list, Func<TItem, TValue> accessor, TValue defaultValue = default(TValue), Predicate<TItem> predicate = null)
```

- **Description**: Searches for the first item in the list that matches a given predicate and accesses its value using a specified accessor function. If no predicate is provided, it returns the value of the first item. If no item matches, it returns the provided default value.
- **Parameters**:
  - `IEnumerable<TItem> list`: The list to search through.
  - `Func<TItem, TValue> accessor`: A delegate for selecting the value from an item.
  - `TValue defaultValue`: The default value to return if no matching item is found.
  - `Predicate<TItem> predicate`: An optional condition to match the items against.
  
### ConvertAll

```csharp
public static TTarget[] ConvertAll<TSource, TTarget>(this TSource[] source, Func<TSource, TTarget> converter)
```

- **Description**: Converts each element in an array to another type using a specified conversion function, returning a new array of the target type.
- **Parameters**:
  - `TSource[] source`: The array to convert.
  - `Func<TSource, TTarget> converter`: A function that converts a source type to a target type.
- **Returns**: An array of `TTarget`, with each element being the result of converting an element from the source array.

### ToHashSet

```csharp
public static HashSet<T> ToHashSet<T>(this IEnumerable<T> values, IEqualityComparer<T> comparer = null)
```

- **Description**: Converts an enumerable collection to a `HashSet`, optionally using a custom equality comparer.
- **Parameters**:
  - `IEnumerable<T> values`: The collection of items to convert into a hash set.
  - `IEqualityComparer<T> comparer`: An optional equality comparer to use for comparison.
- **Returns**: A `HashSet<T>` containing unique items from the input collection.

### DistinctBy

```csharp
public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
```

- **Description**: Returns distinct elements from a collection according to a specified key selector.
- **Parameters**:
  - `IEnumerable<TSource> source`: The collection to process.
  - `Func<TSource, TKey> keySelector`: A function to select the key used for determining distinct elements.
- **Returns**: A sequence of distinct elements from the source collection, determined by the specified key.
```