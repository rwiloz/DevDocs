Sure, here are the inline XML comments for the provided code:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Strings
{
    /// <summary>
    /// Represents values that are similar to a given criteria along with the degree of difference.
    /// </summary>
    /// <typeparam name="TValue">Type of values to compare.</typeparam>
    public class SimilarValue<TValue>
    {
        /// <summary>
        /// Get the difference between the criteria and the value.
        /// </summary>
        public double Difference { get; private set; }

        /// <summary>
        /// Get the value of the SimilarValue instance.
        /// </summary>
        public TValue Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the SimilarValue class.
        /// </summary>
        /// <param name="value">The value to compare with.</param>
        /// <param name="difference">The difference between the criteria and the value.</param>
        public SimilarValue(TValue value, double difference)
        {
            Difference = difference;
            Value = value;
        }

        /// <summary>
        /// Returns a string represention of SimilarValue with its difference.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("'{0}' ({1:0%})", Value, Difference);
        }
    }

    /// <summary>
    /// Compares two SimilarValue instances.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    class SimilarValueComparer<TValue> : Comparer<SimilarValue<TValue>>
    {
        /// <summary>
        /// Compares two SimilarValue instances.
        /// </summary>
        public override int Compare(SimilarValue<TValue> x, SimilarValue<TValue> y)
        {
            return -x.Difference.CompareTo(y.Difference);
        }
    }

    /// <summary>
    /// Contains utility methods for determining similarity between strings.
    /// </summary>
    public static class ApproximateDistanceHelper
    {
        /// <summary>
        /// Calculates the amount of difference between two strings.
        /// </summary>
        public static double WordDifference(this string thisValue, string value)
        {
            // Implementation omitted...
        }

        /// <summary>
        /// Returns the difference between two strings.
        /// </summary>
        public static double Difference(this string thisValue, string value, bool forbitSplit = false)
        {
            // Implementation omitted...
        }

        /// <summary>
        /// Returns a collection of items from the input list that are similar to the specified value.
        /// </summary>
        public static IEnumerable<SimilarValue<TValue>> FindSimilarValues<TValue>(this IEnumerable<TValue> list, string value, Func<TValue, string> stringConverter, double threshold = 0.5)
        {
            // Implementation omitted...
        }
    }
}
```

Please note that the actual methods' code is omitted in the comments. You will need to adjust the comments accordingly if you update those methods' implementation.