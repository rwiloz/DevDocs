# Class Name: ListExtensions

This class provides several extension methods for operations on lists. 

## Method 1: FirstOrDefaultValue
Function signature: 
```Csharp
public static TValue FirstOrDefaultValue<TItem, TValue>(this IEnumerable<TItem> list, Func<TItem, TValue> accessor, TValue defaultValue = default(TValue), Predicate<TItem> predicate = null)
```
This extension method for `IEnumerable<TItem>` evaluates each item on the input list until it finds one that satisfies the predicate (if any). If the predicate is true for an item (or if there is no predicate), it returns the value of that item accessed by the provided function. If no such item is found, it returns the specified default value.

## Method 2: ConvertAll
Function signature: 
```Csharp
public static TTarget[] ConvertAll<TSource, TTarget>(this TSource[] source, Func<TSource, TTarget> converter)
```
This extension method for `TSource[]` applies a provided converter function to all elements of the source array and returns an array of the converted elements in `TTarget[]`.

## Method 3: ToHashSet
Function signature: 
```Csharp
public static HashSet<T> ToHashSet<T>(this IEnumerable<T> values, IEqualityComparer<T> comparer = null)
```
This extension method for `IEnumerable<T>` converts a collection or list of items into a HashSet. Providing a comparer is optional.

## Method 4: DistinctBy
Function signature: 
```Csharp
public static IEnumerable<TSource> DistinctBy<TSource, TKey> (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
```
This extension method for `IEnumerable<TSource>` allows for retrieval of distinct elements based on a key. It selects distinct elements from the source by invoking the provided key selection function on each element, and keeps adding them to the knownKeys HashSet until it encounters a key already in the knownKeys HashSet. Those elements for which keys are already present in the knownKeys HashSet are skipped.