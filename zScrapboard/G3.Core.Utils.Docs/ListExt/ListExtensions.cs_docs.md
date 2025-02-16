---
title: "ListExtensions: Utility Methods for Collections"
date: 2023-10-14
description: "Documentation of the ListExtensions class, offering utility methods for manipulating collections in C#."
draft: false
toc: true
---

# Overview

The ListExtensions class provides a collection of extension methods that simplify common operations on lists and arrays. These methods enhance the capabilities of collections in C#, making it easier to manipulate and query data.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace G3.Core.Utils.ListExt
{
    public static class ListExtensions
    {
        /// <summary>
        /// Returns the first element's value in a sequence that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        /// <typeparam name="TItem">The type of the elements in the list.</typeparam>
        /// <typeparam name="TValue">The type of the value to retrieve.</typeparam>
        /// <param name="list">The list to search.</param>
        /// <param name="accessor">The function to extract the value from the element.</param>
        /// <param name="defaultValue">The default value to return if no element is found.</param>
        /// <param name="predicate">An optional function to test each element for a condition.</param>
        /// <returns>The first element that satisfies the condition or the default value.</returns>
        public static TValue FirstOrDefaultValue<TItem, TValue>(this IEnumerable<TItem> list, Func<TItem, TValue> accessor, TValue defaultValue = default, Predicate<TItem> predicate = null)
        {
            foreach (var item in list)
            {
                if (predicate != null && !predicate(item)) continue;
                return accessor(item);
            }
            return defaultValue;
        }

        /// <summary>
        /// Converts an array of one type to an array of another type.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the source array.</typeparam>
        /// <typeparam name="TTarget">The type of the elements of the target array.</typeparam>
        /// <param name="source">The source array to convert.</param>
        /// <param name="converter">A function to convert each element from one type to another.</param>
        /// <returns>An array of the target type containing the converted elements from the source array.</returns>
        public static TTarget[] ConvertAll<TSource, TTarget>(this TSource[] source, Func<TSource, TTarget> converter)
        {
            if (source == null) return null;

            TTarget[] result = new TTarget[source.Length];

            for (int i = 0; i < source.Length; i++)
                result[i] = converter(source[i]);

            return result;
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified key selector to determine equality.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key to distinguish elements.</typeparam>
        /// <param name="source">The sequence to remove duplicate elements from.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <returns>An IEnumerable<T> that contains distinct elements from the source sequence.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Determines whether a sequence is null or empty.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the source sequence.</typeparam>
        /// <param name="source">The sequence to test.</param>
        /// <returns>true if the sequence is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return true;

            if (source.Count() < 1)
                return true;

            return false;
        }
    }
}
```

## Methods

### FirstOrDefaultValue

- **Purpose**: Retrieves the value of the first element in a sequence that satisfies a condition, or a default value if no such element exists.
- **Parameters**:
  - `TItem`: Type of the elements in the list.
  - `TValue`: Type of the value to retrieve.
  - `list`: The sequence to search.
  - `accessor`: Function to extract the value.
  - `defaultValue`: Default value to return if no match is found.
  - `predicate`: Optional predicate to apply to each element.
- **Returns**: The extracted value or the default value.

### ConvertAll

- **Purpose**: Converts an array from one type to another.
- **Parameters**:
  - `TSource`: Type of the source array elements.
  - `TTarget`: Type of the target array elements.
  - `source`: Array to be converted.
  - `converter`: Function that defines the conversion logic.
- **Returns**: An array of the converted type.

### DistinctBy

- **Purpose**: Removes duplicate elements from a sequence using a specified key selector.
- **Parameters**:
  - `TSource`: Type of the source elements.
  - `TKey`: Type of the key for comparison.
  - `source`: Sequence to process.
  - `keySelector`: Function to identify the key for each element.
- **Returns**: A sequence containing distinct elements.

### IsNullOrEmpty

- **Purpose**: Checks if a sequence is null or contains no elements.
- **Parameters**:
  - `T`: Type of the source sequence elements.
  - `source`: Sequence to evaluate.
- **Returns**: `true` if null or empty, otherwise `false`.
```