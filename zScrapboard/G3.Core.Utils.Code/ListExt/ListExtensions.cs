Here's how you summarize your code with XML documentation:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace G3.Core.Utils.ListExt
{
    /// <summary>
    /// A container for methods extending basic list functionality.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Returns the first value in list according to provided predicate, or default if none is found.
        /// </summary>
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
        /// Convert all elements in source array to the target type using provided converter function.
        /// </summary>
        public static TTarget[] ConvertAll<TSource, TTarget>(this TSource[] source, Func<TSource, TTarget> converter)
        {
            if (source == null) return null;

            TTarget[] result = new TTarget[source.Length];

            for (int i = 0; i < source.Length; i++)
                result[i] = converter(source[i]);

            return result;
        }

        //public static HashSet<T> ToHashSet<T>(this IEnumerable<T> values, IEqualityComparer<T> comparer = null)
        //{
        //    if (values == null) return null;
        //    var result = values as HashSet<T>;
        //    return result ?? (comparer == null ? new HashSet<T>(values) : new HashSet<T>(values, comparer));
        //}

        /// <summary>
        /// Returns distinct elements from source by a specific key.
        /// </summary>
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
        /// Checks if the source list is null or is empty.
        /// </summary>
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