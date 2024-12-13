using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Strings
{
    public class SimilarValue<TValue>
    {
        public double Difference { get; private set; }
        public TValue Value { get; private set; }

        public SimilarValue(TValue value, double difference)
        {
            Difference = difference;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("'{0}' ({1:0%})", Value, Difference);
        }
    }

    class SimilarValueComparer<TValue> : Comparer<SimilarValue<TValue>>
    {
        public override int Compare(SimilarValue<TValue> x, SimilarValue<TValue> y)
        {
            return -x.Difference.CompareTo(y.Difference);
        }
    }

    public static class ApproximateDistanceHelper
    {
        /// <summary>
        /// Calculation of the amount of difference between two strings.
        /// Phonetic algorithm: Metaphone (http://en.wikipedia.org/wiki/Metaphone)
        /// Metric algorithm: Levenshtein distance (http://en.wikipedia.org/wiki/Levenshtein_distance)
        /// Normalisation by max of string length.
        /// Returns amount of difference between two strings:
        ///  0 - very similar
        ///  1 - very different
        /// </summary>
        public static double WordDifference(this string thisValue, string value)
        {
            Metaphone m = new Metaphone();
            string m1 = m.Encode(thisValue);
            string m2 = m.Encode(value);
            int[][] d = new int[m1.Length + 1][];
            for (int i = 0; i <= m1.Length; i++) d[i] = new int[m2.Length + 1];
            for (int i = 0; i <= m1.Length; i++) d[i][0] = i;
            for (int j = 0; j <= m2.Length; j++) d[0][j] = j;
            for (int j = 1; j <= m2.Length; j++)
            {
                for (int i = 1; i <= m1.Length; i++)
                {
                    if (m1[i - 1] == m2[j - 1])
                        d[i][j] = d[i - 1][j - 1];
                    else
                        d[i][j] = Math.Min(d[i - 1][j] + 1, Math.Min(d[i][j - 1] + 1, d[i - 1][j - 1] + 1));
                }
            }
            return (double)d[m1.Length][m2.Length] / (double)Math.Max(m1.Length, m2.Length);
        }

        public static double Difference(this string thisValue, string value, bool forbitSplit = false)
        {
            if (forbitSplit)
            {
                var diff = thisValue.WordDifference(value);
                if (thisValue.Length >= 2 && value.StartsWith(thisValue)) diff /= 3.0;
                return diff;
            }
            else
            {
                double minDiff = value.Difference(thisValue, true);
                if (minDiff < 0.5 || !value.Contains(' ') || thisValue.Contains(' ')) return minDiff;
                var newValues = value.Split(' ');
                foreach (var s in newValues)
                {
                    var diff = s.Difference(thisValue, true);
                    if (minDiff > diff) minDiff = diff;
                    else if (diff >= 0.5) minDiff *= 1.5;
                }
                return minDiff;
            }
        }

        public static IEnumerable<SimilarValue<TValue>> FindSimilarValues<TValue>(this IEnumerable<TValue> list, string value, Func<TValue, string> stringConverter, double threshold = 0.5)
        {
            List<SimilarValue<TValue>> result = new List<SimilarValue<TValue>>();
            foreach (var item in list)
            {
                var itemValue = stringConverter(item);
                var difference = itemValue.Difference(value);
                if (difference < threshold) continue;
                result.Add(new SimilarValue<TValue>(item, difference));
            }
            var comparer = new SimilarValueComparer<TValue>();
            result.Sort(comparer);
            return result;
        }
    }
}
