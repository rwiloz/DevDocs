---
title: DictionaryHelpers Utility Class
author: Your Name
date: 2023-10-19
description: Utility methods for dictionary operations, facilitating common tasks such as grouping and filtering.
---

# G3.Core.Utils.Dictionaries.DictionaryHelpers

This static class provides various utility methods to facilitate dictionary operations for developers working with .NET collections. The methods cover common tasks such as converting lists to dictionaries, counting elements, checking for emptiness, and retrieving values with optional default values.

## Methods

### ToDictionaryList\<TKey, TValue\>

```csharp
public static Dictionary<TKey, List<TValue>> ToDictionaryList<TKey, TValue>(
    this IEnumerable<TValue> originalList, 
    Func<TValue, TKey> keyDelegate,
    IEqualityComparer<TKey> comparer = null, 
    Func<TValue, bool> filterDelegate = null)
```

Converts a list to a dictionary where each key maps to a list of values. Allows for filtering of elements before mapping.

#### Type Parameters
- `TKey`: Type for the dictionary keys.
- `TValue`: Type for the dictionary values.

#### Parameters
- `originalList`: The data source list to be converted.
- `keyDelegate`: Function that provides the key for a given value.
- `comparer`: Optional. Used to compare keys; default comparer is used if none is provided.
- `filterDelegate`: Optional. Predicate to filter values; if null, all values are included.

#### Returns
- A dictionary mapping each key to a corresponding list of values.

### ToDictionaryList\<TKey, TValue, TElement\>

```csharp
public static Dictionary<TKey, List<TValue>> ToDictionaryList<TKey, TValue, TElement>(
    this IEnumerable<TElement> originalList, 
    Func<TElement, TKey> keyDelegate,
    Func<TElement, TValue> valueDelegate, 
    IEqualityComparer<TKey> comparer = null,
    Predicate<TElement> filterDelegate = null)
```

Extends the previous method by allowing transformation of elements to values before mapping.

#### Type Parameters
- `TKey`: Type for the dictionary keys.
- `TValue`: Type for the dictionary values.
- `TElement`: Type of the elements in the original list.

#### Parameters
- `originalList`: The data source list.
- `keyDelegate`: Function to extract a key from an element.
- `valueDelegate`: Function to extract a value from an element.
- `comparer`: Optional. Used for comparing keys.
- `filterDelegate`: Optional. Predicate to filter elements.

#### Returns
- A dictionary mapping each key to a list of transformed values.

### ToDictionaryValue\<TKey, TValue\>

```csharp
public static Dictionary<TKey, TValue> ToDictionaryValue<TKey, TValue>(
    this IEnumerable<TValue> originalList,
    Func<TValue, TKey> keyDelegate, 
    bool useFirstIfExists = true, 
    IEqualityComparer<TKey> comparer = null,
    Func<TValue, bool> filterDelegate = null)
```

Creates a dictionary with single-value mappings, optionally using the first occurrence for duplicate keys.

#### Type Parameters
- `TKey`: Type for the dictionary keys.
- `TValue`: Type for the dictionary values.

#### Parameters
- `originalList`: Source list.
- `keyDelegate`: Provides the key for each value.
- `useFirstIfExists`: Determines whether to use the first mapped item in case of duplicate keys.
- `comparer`: Optional. For comparing keys.
- `filterDelegate`: Optional. Predicate to filter values.

#### Returns
- A dictionary mapping each key to a single value.

### Count

```csharp
public static int Count(this IEnumerable list)
```

Counts the total number of elements in a sequence.

#### Parameters
- `list`: The collection to be counted.

#### Returns
- The total count of elements.

### IsEmpty

```csharp
public static bool IsEmpty(this IEnumerable list)
```

Determines whether a collection is empty.

#### Parameters
- `list`: The collection to check.

#### Returns
- `true` if the collection has no elements; otherwise, `false`.

### Get\<TKey, TValue\>

```csharp
public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
```

Retrieves a value from a dictionary or returns a default value if the key is not found.

#### Type Parameters
- `TKey`: Type of the dictionary key.
- `TValue`: Type of the dictionary value.

#### Parameters
- `dict`: The dictionary from which to retrieve the value.
- `key`: The key whose value to get.
- `defaultValue`: The value to return if the key is not found.

#### Returns
- The value associated with `key`, or `defaultValue` if `key` is not present.

### GetNullable\<TKey, TValue\>

```csharp
public static TValue? GetNullable<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue? defaultValue = null)
    where TValue : struct
```

Fetches a value from a dictionary, suitable for nullable types, with an option to specify a default.

#### Type Parameters
- `TKey`: Type of the dictionary keys.
- `TValue`: Type of the dictionary values (struct).

#### Parameters
- `dict`: Dictionary to search for the key.
- `key`: The key to look up.
- `defaultValue`: Default value if the key is absent.

#### Returns
- The found value or `defaultValue`.

### ToDictionaryIgnoreCase\<T\>

```csharp
public static Dictionary<string, T> ToDictionaryIgnoreCase<T>(this Dictionary<string, T> dict)
```

Creates a new dictionary from an existing one, with case-insensitive key comparison.

#### Type Parameters
- `T`: Type of the values in the dictionary.

#### Parameters
- `dict`: The original dictionary.

#### Returns
- A new dictionary with case-insensitive key comparison.
