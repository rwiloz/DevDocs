using System;
using System.Collections.Generic;

namespace G3.Core.Utils.LinqExt
{
    public static class ListExtensions
    {
        public static TValue FirstOrDefaultValue<TItem, TValue>(this IEnumerable<TItem> list, Func<TItem, TValue> accessor, TValue defaultValue = default(TValue), Predicate<TItem> predicate = null)
        {
            foreach (var item in list)
            {
                if (predicate != null && !predicate(item)) continue;
                return accessor(item);
            }
            return defaultValue;
        }

        public static TTarget[] ConvertAll<TSource, TTarget>(this TSource[] source, Func<TSource, TTarget> converter)
        {
            if (source == null) return null;

            TTarget[] result = new TTarget[source.Length];

            for (int i = 0; i < source.Length; i++)
                result[i] = converter(source[i]);

            return result;
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> values, IEqualityComparer<T> comparer = null)
        {
            if (values == null) return null;
            var result = values as HashSet<T>;
            return result ?? (comparer == null ? new HashSet<T>(values) : new HashSet<T>(values, comparer));
        }

        //http://stackoverflow.com/questions/1300088/distinct-with-lambda
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
