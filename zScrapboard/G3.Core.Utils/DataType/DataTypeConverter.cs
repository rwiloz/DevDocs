using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.DataType
{
    public static class DataTypeConverter
    {
        public static bool ToBoolean(this string value, bool defaultValue = false)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            if (value.Length == 1)
            {
                return (string.Compare(value, "1", true) == 0) || (string.Compare(value, "Y", true) == 0);
            }

            return (string.Compare(value, "true", true) == 0) || (string.Compare(value, "yes", true) == 0);
        }

        public static decimal ToDecimal(this string parseValue)
        {
            return decimal.TryParse(parseValue, out var value) ? value : 0;
        }

        public static decimal? ToNullableDecimal(this string parseValue)
        {
            var value = new decimal?();
            if (!string.IsNullOrEmpty(parseValue))
            {
                value = decimal.TryParse(parseValue, out var outValue) ? outValue : 0;
            }
            return value;
        }

        public static double? ToNullableDouble(this string parseValue)
        {
            var value = new double?();
            if (!string.IsNullOrEmpty(parseValue))
            {
                value = double.TryParse(parseValue, out var outValue) ? outValue : 0;
            }
            return value;
        }

        public static int ToInt32(this string parseValue, int defaultValue = 0)
        {
            if (!Int32.TryParse(parseValue, out var value))
            {
                value = defaultValue;
            }

            return value;
        }

        public static long ToInt64(this string parseValue, long defaultValue = 0)
        {
            if (!Int64.TryParse(parseValue, out var value))
            {
                value = defaultValue;
            }

            return value;
        }

        public static IEnumerable<long> TryParseToInt64List(string[] stringList)
        {
            var parseValues = new List<long>();
            foreach (var s in stringList)
            {
                if (long.TryParse(s, out var value))
                {
                    parseValues.Add(value);
                }
            }

            return parseValues;
        }

        public static int NumberOfDecimalPlaces(this decimal? value)
        {
            var places = 0;
            var svalue = value.GetValueOrDefault().ToString();
            svalue = svalue.TrimEnd('0');
            // TODO use culture for .
            var indexSeparator = svalue.IndexOf('.');
            if (indexSeparator > 0)
            {
                places = svalue[(indexSeparator + 1)..].Length;
            }

            return places;
        }

        public static string ToString(this Decimal? decimalValue, int precision = 2)
        {
            var value = string.Empty;
            if (decimalValue.HasValue)
            {
                var dec = new string('#', precision);
                dec = "0." + dec;
                value = decimalValue.Value.ToString(dec);
            }

            return value;
        }

        public static long? ToNullableInt64(this string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            if (long.TryParse(value, out var result)) return result;
            else return null;
        }

        public static decimal RemoveTrailingZeros(this decimal value)
        {
            return value / 1.000000000000000000000000000000000m;
        }

        public static decimal? RemoveTrailingZeros(this decimal? value)
        {
            return value.HasValue ? (decimal?)value.Value.RemoveTrailingZeros() : null;
        }

        public static int GetDecimalScale(this decimal value)
        {
            // don't ask - simply believe
            return BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
        }

        public static T ToEnum<T>(this string value, T defaultValue)
             where T : struct
        {
            if(!Enum.TryParse(value, false, out T enumValue))
            {
                return defaultValue;
            }
            return enumValue;
        }

        public static string ToHex(this byte[] data)
        {
            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
                sb.Append(' ');
            }

            return sb.ToString();
        }

        public static string ToHex(this string data)
        {
            var b = Encoding.UTF8.GetBytes(data);
            return b.ToHex();
        }
    }
}
