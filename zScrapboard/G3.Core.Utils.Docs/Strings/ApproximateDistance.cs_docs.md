---
title: "G3.Core.Utils.Strings Namespace"
date: 2023-10-12
description: "This documentation provides details about the G3.Core.Utils.Strings namespace and its functionality."
draft: false
---

# G3.Core.Utils.Strings Namespace

The `G3.Core.Utils.Strings` namespace provides tools for comparing string similarity and includes helper classes and functions to determine differences between strings using phonetic and metric algorithms.

## Classes

### `SimilarValue<TValue>`

The `SimilarValue<TValue>` class represents a generic value with its associated difference metric.

#### Properties

- `Difference`: A `double` representing the difference between a reference value and the actual value.
- `Value`: A `TValue` generic value being compared.

#### Methods

- `SimilarValue(TValue value, double difference)`: Constructor to initialize a `SimilarValue` instance with the given value and difference.
- `ToString()`: Overrides the `ToString()` method to provide a formatted string with the value and its percentage similarity.

### `SimilarValueComparer<TValue>`

The `SimilarValueComparer<TValue>` class is a custom comparer for `SimilarValue<TValue>` objects, allowing them to be compared based on their difference.

#### Methods

- `Compare(SimilarValue<TValue> x, SimilarValue<TValue> y)`: Compares two `SimilarValue<TValue>` objects and returns an integer indicating their relative order based on the difference.

## Static Class

### `ApproximateDistanceHelper`

The `ApproximateDistanceHelper` static class contains methods to calculate the difference between strings using phonetic and metric algorithms.

#### Methods

- `WordDifference(this string thisValue, string value)`: 
  - Calculates the difference between two strings using the Metaphone phonetic algorithm and the Levenshtein distance metric, normalizing by the maximum string length. 
  - Returns a double in the range [0, 1], where 0 indicates very similar strings and 1 indicates very different strings.

- `Difference(this string thisValue, string value, bool forbitSplit = false)`: 
  - Computes the difference between two strings, optionally forbidding splitting of the strings. 
  - Considers differences when strings contain spaces and adjusts the result based on the threshold.

- `FindSimilarValues<TValue>(this IEnumerable<TValue> list, string value, Func<TValue, string> stringConverter, double threshold = 0.5)`: 
  - Searches a list of generic `TValue` objects for those similar to the specified string `value`. 
  - Uses a delegate `stringConverter` to convert `TValue` to a string for comparison. 
  - Filters results based on a specified `threshold` and returns them sorted by similarity.

## Usage

These classes and methods are designed to enable developers to perform sophisticated comparisons of string data, identifying closely related values based on customizable criteria. They are particularly useful in scenarios involving text processing, search algorithm enhancements, and automated matching tasks.

Ensure the `Metaphone` algorithm implementation is available when using these methods, as it is required for executing the phonetic comparisons.
```