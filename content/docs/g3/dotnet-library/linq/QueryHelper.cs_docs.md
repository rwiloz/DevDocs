---
title: "Query Helper"
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

# QueryHelper Class

The `QueryHelper` class is a `static` utility class defined in the G3.Core.Utils.LinqExt namespace. This utility class contains extension methods for `IQueryable<T>` and `IOrderedQueryable<T>` to facilitate dynamic querying and ordering on data collections that implements IQueryable interface such as Entity Framework queries.

## Methods

### OrderBy Methods (Overloaded)

- `OrderBy<T>(this IQueryable<T> source, string propertyName, string orderBy)`: Orders a given IQueryable source based on a specified property name. The ordering`orderBy` is determined based on the `string` passed ("asc" for ascending, "desc" for descending).

- `OrderBy<T>(this IQueryable<T> source, string propertyName)`: An overload that orders IQueryable source in ascending order by default.

- `OrderByDescending<T>(this IQueryable<T> source, string propertyName)`: Orders IQueryable source in descending order based on a specified property name.

### ThenBy Methods

- `ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)`: Further orders an already ordered IQueryable source in ascending order based on a given property name.

- `ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)`: Further orders an already ordered IQueryable source in descending order based on a given property name.

### Where Methods (Overloaded)

- `Where<T>(this IQueryable<T> source, string propertyName, string value, bool startWithIfString = false)`: Filters an IQueryable source based on a specified property name and a value. It provides an option to use the `StartsWith` method if the property type is a string.

- `Where<T>(this IQueryable<T> source, string propertyName, string value, QueryHelperBinarySearch searchType)`: An overloaded version of the previous method. It allows more advanced filtering options such as GreaterThanOrEqual and LessThanOrEqual operations specified by the `QueryHelperBinarySearch` enum type. 

### ApplyOrder Method (Private)

- `ApplyOrder<T>(IQueryable<T> source, string propertyName, string methodName)`: A private utility method helping to reflectively call Linq's OrderBy/ThenBy methods based on a specified property name and a method name.

## Enum

- `QueryHelperBinarySearch`: Contains two values `GreaterThanOrEqual`, `LessThanOrEqual`. These values are used in the overloaded `Where` method for comparing property values with a given value.