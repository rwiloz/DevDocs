---
title: "Similar Value"
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

# SimilarValue

This C# class is defined within the namespace G3.Core.Utils.Strings. It is a generic class for values of type `TValue`. It consists of two properties:

- `Difference`: A `double` value indicating the difference or alteration between two instances of type `TValue`.
- `Value`: An instance of type `TValue`.

The class also includes an overloaded ToString() method for custom string representation.

----

# SimilarValueComparer

This class extends the `Comparer<SimilarValue<TValue>>` class. It overloads the `Compare()` method, which compares two `SimilarValue` instances based on the `Difference` property. The comparison is reversed with `-x.Difference.CompareTo(y.Difference)` to allow for a descending sort order.

----

# ApproximateDistanceHelper

This is a static helper class that provides methods for examining the difference or distance between string values.

- `WordDifference(this string thisValue, string value)`: Calculation of the amount of difference between two strings, using the Metaphone phonetic algorithm and Levenshtein distance metric algorithm. The difference is normalized by the maximum string length. 
- `Difference(this string thisValue, string value, bool forbitSplit = false)`: Returns difference between `thisValue` and `value`. If `forbitSplit` is true, only WordDifference will be used. If it is false, additional checks and optimizations are performed.
- `FindSimilarValues<TValue>(this IEnumerable<TValue> list, string value, Func<TValue, string> stringConverter, double threshold = 0.5)`: Searches for similar values in the provided `IEnumerable<TValue>` list. The `stringConverter` function is used to convert the `TValue` instances to strings. The `threshold` value determines the cut-off for any differences between the strings. The results are sorted in decreasing order of similarity (i.e., increasing order of difference).

These methods provide a mechanism to check the approximate similarity of different string values based on certain algorithms.