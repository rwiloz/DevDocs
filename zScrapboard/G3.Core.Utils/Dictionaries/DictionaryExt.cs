using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace G3.Core.Utils.Dictionaries
{
    public static class DictionaryHelpers
    {
        /// <summary>
        /// Split list into dictionary with grouped values for the same key.
        /// </summary>
        /// <typeparam name="TKey">Type for keys</typeparam>
        /// <typeparam name="TValue">Type for values</typeparam>
        /// <param name="originalList">Data source</param>
        /// <param name="keyDelegate">Delegate to get a key value</param>
        /// <param name="comparer">Key comparer, by default - default equality comparer for the TKey</param>
        /// <returns></returns>
        public static Dictionary<TKey, List<TValue>> ToDictionaryList<TKey, TValue>(
            this IEnumerable<TValue> originalList, Func<TValue, TKey> keyDelegate,
            IEqualityComparer<TKey> comparer = null, Func<TValue, bool> filterDelegate = null)
        {
            var result = new Dictionary<TKey, List<TValue>>(comparer ?? EqualityComparer<TKey>.Default);
            foreach (var item in originalList)
            {
                if (filterDelegate != null && !filterDelegate(item)) continue;
                TKey key = keyDelegate(item);
                List<TValue> list;
                if (!result.TryGetValue(key, out list))
                {
                    list = new List<TValue>();
                    result[key] = list;
                }

                list.Add(item);
            }

            return result;
        }

        /// <summary>
        /// Split list into dictionary with grouped values for the same key.
        /// </summary>
        /// <typeparam name="TKey">Type for keys.</typeparam>
        /// <typeparam name="TValue">Type for values.</typeparam>
        /// <typeparam name="TElement">Type of linking element.</typeparam>
        /// <param name="originalList">Data source.</param>
        /// <param name="keyDelegate">Delegate to get a key value.</param>
        /// <param name="comparer">Key comparer, by default - default equality comparer for the TKey.</param>
        /// <param name="filterDelegate">Optional filter predicate.</param>
        /// <param name="valueDelegate">Value accessor.</param>
        /// <returns></returns>
        public static Dictionary<TKey, List<TValue>> ToDictionaryList<TKey, TValue, TElement>(
            this IEnumerable<TElement> originalList, Func<TElement, TKey> keyDelegate,
            Func<TElement, TValue> valueDelegate, IEqualityComparer<TKey> comparer = null,
            Predicate<TElement> filterDelegate = null)
        {
            var result = new Dictionary<TKey, List<TValue>>(comparer ?? EqualityComparer<TKey>.Default);
            foreach (var item in originalList)
            {
                if (filterDelegate != null && !filterDelegate(item)) continue;
                TKey key = keyDelegate(item);
                List<TValue> list;
                if (!result.TryGetValue(key, out list))
                {
                    list = new List<TValue>();
                    result[key] = list;
                }

                list.Add(valueDelegate(item));
            }

            return result;
        }

        public static Dictionary<TKey, TValue> ToDictionaryValue<TKey, TValue>(this IEnumerable<TValue> originalList,
            Func<TValue, TKey> keyDelegate, bool useFirstIfExists = true, IEqualityComparer<TKey> comparer = null,
            Func<TValue, bool> filterDelegate = null)
        {
            var result = new Dictionary<TKey, TValue>(comparer ?? EqualityComparer<TKey>.Default);
            foreach (var item in originalList)
            {
                if (filterDelegate != null && !filterDelegate(item)) continue;
                TKey key = keyDelegate(item);
                if (!useFirstIfExists || !result.ContainsKey(key)) result[key] = item;
            }

            return result;
        }

        public static Dictionary<TKey, TValue> ToDictionaryValue<TKey, TValue, TElement>(
            this IEnumerable<TElement> originalList, Func<TElement, TKey> keyDelegate,
            Func<TElement, TValue> valueDelegate, bool useFirstIfExists = true, IEqualityComparer<TKey> comparer = null,
            Func<TElement, bool> filterDelegate = null)
        {
            var result = new Dictionary<TKey, TValue>(comparer ?? EqualityComparer<TKey>.Default);
            foreach (var item in originalList)
            {
                if (filterDelegate != null && !filterDelegate(item)) continue;
                TKey key = keyDelegate(item);
                if (!useFirstIfExists || !result.ContainsKey(key)) result[key] = valueDelegate(item);
            }

            return result;
        }

        public static int Count(this IEnumerable list)
        {
            int result = 0;
            foreach (var item in list)
                result++;
            return result;
        }

        public static bool IsEmpty(this IEnumerable list)
        {
            foreach (var item in list)
                return false;
            return true;
        }

        public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key,
            TValue defaultValue = default(TValue))
        {
            TValue result;
            if (dict.TryGetValue(key, out result)) return result;
            else return defaultValue;
        }

        public static TValue? GetNullable<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key,
            TValue? defaultValue = null)
            where TValue : struct
        {
            TValue result;
            if (dict.TryGetValue(key, out result)) return result;
            else return defaultValue;
        }

        public static Dictionary<string, T> ToDictionaryIgnoreCase<T>(this Dictionary<string, T> dict)
        {
            var newDict = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);

            foreach (var (key, value) in dict)
            {
                if (key != null) newDict.Add(key, value);
            }

            return newDict;
        }
    }

}