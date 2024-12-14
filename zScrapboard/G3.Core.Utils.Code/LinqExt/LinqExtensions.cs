Using System;
using System.Collections.Generic;

namespace G3.Core.Utils.LinqExt
{
    /// <summary>
    /// Provides static extension methods for List.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Returns the first value of the access to a property from a list or a default value if the list is empty.
        /// Optionally, a predicate can be used to filter out results.
        /// </summary>
        /// <typeparam name="TItem">The type of items in the list.</typeparam>
        /// <typeparam name="TValue">The type of accessed value.</typeparam>
        /// <param name="list">The source list.</param>
        /// <param name="accessor">Function to access property from list item.</param>
        /// <param name="defaultValue">Default value to return if list is empty.</param>
        /// <param name="predicate">Optional predicate to filter list items.</param>
        /// <returns>The first value or the default value if list is empty.</returns>
        public static TValue FirstOrDefaultValue<TItem, TValue>(this IEnumerable<TItem> list, Func<TItem, TValue> accessor, TValue defaultValue = default(TValue), Predicate<TItem> predicate = null)
        {
            foreach (var item in list)
            {
                if (predicate != null && !predicate(item)) continue;
                return accessor(item);
            }
            return defaultValue;
        }

        /// <summary>
        /// Converts all items in the source array from one type to another.
        /// </summary>
        /// <typeparam name="TSource">The type of items in the source array.</typeparam>
        /// <typeparam name="TTarget">The type of items in the target array.</typeparam>
        /// <param name="source">Source array.</param>
        /// <param name="converter">Function to convert source item to target item.</param>
        /// <returns>Array of converted items.</returns>
        public static TTarget[] ConvertAll<TSource, TTarget>(this TSource[] source, Func<TSource, TTarget> converter)
        {
            if (source == null) return null;

            TTarget[] result = new TTarget[source.Length];

            for (int i = 0; i < source.Length; i++)
                result[i] = converter(source[i]);

            return result;
        }

        /// <summary>
        /// Converts an IEnumerable of values into a HashSet.
        /// </summary>
        /// <typeparam name="T">The type of items in the enumerable values.</typeparam>
        /// <param name="values">Enumerable of values.</param>
        /// <param name="comparer">Equality comparer for values.</param>
        /// <returns>A new HashSet containing the values.</returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> values, IEqualityComparer<T> comparer = null)
        {
            if (values == null) return null;
            var result = values as HashSet<T>;
            return result ?? (comparer == null ? new HashSet<T>(values) : new HashSet<T>(values, comparer));
        }

        /// <summary>
        /// Filter out duplicates in source based on a key returned by keySelector function.
        /// </summary>
        /// <typeparam name="TSource">The type of items in source.</typeparam>
        /// <typeparam name="TKey">The type of key returned by keySelector.</typeparam>
        /// <param name="source">Source enumerable.</param>
        /// <param name="keySelector">Function to select key from item.</param>
        /// <returns>IEnumerable without duplicates.</returns>
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
    }
}