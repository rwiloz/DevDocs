---
title: QueryHelper Utility for LINQ Extensions
date: 2023-10-04
draft: false
---

# QueryHelper Utility for LINQ Extensions

The `QueryHelper` class provides a set of extension methods for IQueryable objects to build dynamic queries using property names and ordering directions.

## Overview

Namespace: `G3.Core.Utils.LinqExt`  
Assembly: `G3.Core`  

## Features

The `QueryHelper` class enables the following functionalities:

- Dynamically order IQueryable collections by property names.
- Apply ascending or descending sort orders.
- Build predicates with string values and apply them as conditions on queries.
- Use binary expressions in search queries.

## Methods

### OrderBy

```csharp
public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, string orderBy)
```

Orders the elements of a sequence based on a specified property using a defined order.

#### Parameters

- `source`: The IQueryable collection to sort.
- `propertyName`: The name of the property to sort by.
- `orderBy`: A string specifying the order direction ("asc" for ascending, "desc" for descending).

#### Returns

An IOrderedQueryable of the generic type.

---

```csharp
public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
```

Orders the elements of a sequence in ascending order based on the specified property.

#### Parameters

- `source`: The IQueryable collection to sort.
- `propertyName`: The name of the property to sort by.

#### Returns

An IOrderedQueryable of the generic type.

### OrderByDescending

```csharp
public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
```

Orders the elements of a sequence in descending order based on the specified property.

#### Parameters

- `source`: The IQueryable collection to sort.
- `propertyName`: The name of the property to sort by.

#### Returns

An IOrderedQueryable of the generic type.

### ThenBy

```csharp
public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
```

Performs a subsequent ordering of the elements in a collection in ascending order based on a specified property.

#### Parameters

- `source`: The IOrderedQueryable collection to sort.
- `propertyName`: The name of the property for subsequent sorting.

#### Returns

An IOrderedQueryable of the generic type.

### ThenByDescending

```csharp
public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
```

Performs a subsequent ordering of the elements in a collection in descending order based on a specified property.

#### Parameters

- `source`: The IOrderedQueryable collection to sort.
- `propertyName`: The name of the property for subsequent sorting.

#### Returns

An IOrderedQueryable of the generic type.

### Where

```csharp
public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, string value, bool startWithIfString = false)
```

Filters a sequence of values based on a property name and a string value.

#### Parameters

- `source`: The IQueryable collection to filter.
- `propertyName`: The name of the property to filter by.
- `value`: The string value to compare against.
- `startWithIfString` (optional): Determines whether to filter strings with a "StartsWith" condition.

#### Returns

An IQueryable of the generic type.

---

```csharp
public static IQueryable<T> Where<T>(this IQueryable<T> source, string propertyName, string value, QueryHelperBinarySearch searchType)
```

Applies a binary expression filter on a sequence based on a property value comparison.

#### Parameters

- `source`: The IQueryable collection to filter.
- `propertyName`: The name of the property to filter by.
- `value`: The string value to compare against.
- `searchType`: The type of binary expression to apply (e.g., GreaterThanOrEqual, LessThanOrEqual).

#### Returns

An IQueryable of the generic type.

## Enumerations

### QueryHelperBinarySearch

The `QueryHelperBinarySearch` enumeration defines the binary search types to be used in the `Where` method.

- `GreaterThanOrEqual`: Represents a greater-than-or-equal condition.
- `LessThanOrEqual`: Represents a less-than-or-equal condition.
