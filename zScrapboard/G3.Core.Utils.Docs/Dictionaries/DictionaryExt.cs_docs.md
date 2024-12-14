# DictionaryHelpers Class

This class provides extension methods to manipulate and interact with dictionaries and collections. Below are the methods available in this class:

1. `ToDictionaryList(this IEnumerable<TValue> originalList, Func<TValue, TKey> keyDelegate, IEqualityComparer<TKey> comparer = null, Func<TValue, bool> filterDelegate = null)` 

    - This method converts an enumerable into a dictionary where the keys are the outputs of the supplied function `keyDelegate`, and the values are lists of items that produce the same key. It also allows you to filter out certain items with the `filterDelegate`.

2. `ToDictionaryList<TKey,TValue,TElement>( this IEnumerable<TElement> originalList, Func<TElement, TKey> keyDelegate,Func<TElement, TValue> valueDelegate, IEqualityComparer<TKey> comparer = null,Predicate<TElement> filterDelegate = null)`

    - This method also converts an enumerable into a dictionary, but it operates on a different type of enumerable and allows you to supply a function that further maps enumerable items to the dictionary's value type.

3. `ToDictionaryValue<TKey, TValue>(this IEnumerable<TValue> originalList,Func<TValue, TKey> keyDelegate, bool useFirstIfExists = true, IEqualityComparer<TKey> comparer = null,Func<TValue, bool> filterDelegate = null)`

    - This method converts an enumerable into a dictionary, using the provided function as the key selector. It also accepts a boolean flag to indicate if it should favor the first or last occurrence when there are duplicates.

4. `ToDictionaryValue<TKey, TValue, TElement>...`

    - Similar to the method above, but also maps enumerable elements to a different value type.

5. `Count(this IEnumerable list)`

    - This method returns the total number of items in an enumerable.

6. `IsEmpty(this IEnumerable list)`

    - This method checks if an enumerable is empty or not.

7. `Get<TKey, TValue>...`

    - These methods provide a way to obtain values associated with a given key in a dictionary, returning a default value if the key is not present. One method is for nullable values, and the other is for non-nullable types.

8. `ToDictionaryIgnoreCase<T>(this Dictionary<string, T> dict)`

    - This method converts a dictionary to an equivalent dictionary where the keys comparison is case-insensitive.