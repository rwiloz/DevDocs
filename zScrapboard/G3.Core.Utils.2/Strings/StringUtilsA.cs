using G3.Core.Utils.ListExt;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace G3.Core.Utils.Strings
{
    public static class StringUtils
    {
        public static bool Same(this string data1, string data2)
        {
            if (data1 == null && data2 == null) return true;
            if (data1 == null || data2 == null) return false;

            return string.Equals(data1, data2, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool SameAnyOf(this string data1, string[] data2)
        {
            if (data1 == null && data2 == null) return true;
            if (data1 == null || data2 == null || data2.Length==0) return false;


            return data2.Contains(data1, StringComparer.OrdinalIgnoreCase);
        }

        public static bool SameAnyOf(this string data1, string data2)
        {
            if (data1 == null && data2 == null) return true;
            if (data1 == null || data2 == null) return false;

            return data1.SameAnyOf(data2.Split(','));
        }

        public static bool HasValue(this string data)
        {
            return !string.IsNullOrEmpty(data);
        }

        private const string CEncodeStr = @"GRu/Tr$0XYjvkx3}i;=(1V?)5qh8""zMyIJ2.wsm~-&[EHlf`7!:o_ND^{S,>4<e@BnLp]A+UP 9Fc*#\ta'gC|Kb6ZOQWd%";

        public static string EncodeText(this string data)
        {
            var res = new StringBuilder();
            var ascii = Encoding.ASCII.GetBytes(data);

            foreach (var b in ascii)
            {
                var p = CEncodeStr.IndexOf((char)b);
                if (p >= 0)
                {
                    res.Append((char)(p + 32));
                }
            }

            return res.ToString();
        }

        public static bool IsDigits(this string data)
        {
            return data.All(c => (c >= '0' && c <= '9'));
        }

        public static bool IsDigitsOrPlus(this string data)
        {
            return data.All(c => (c >= '0' && c <= '9') || c == '+');
        }

        public static bool IsDecimal(this string data)
        {
            return data.All(c => (c >= '0' && c <= '9') || c == '.' || c == '-');
        }

        public static bool IsDecimalOrColon(this string data)
        {
            //[ & ] can be used in IPv6
            return data.All(c => (c >= '0' && c <= '9') || c == '.' || c == ':' || c == '[' || c == ']');
        }

        public static bool IsAscii(this string str)
        {
            return Encoding.UTF8.GetByteCount(str) == str.Length;
        }

        public static string DecodeText(this string data)
        {
            var res = new StringBuilder();
            var ascii = Encoding.ASCII.GetBytes(data);

            foreach (var b in ascii)
            {
                if ((b >= 32) && (b <= 126))
                {
                    res.Append(CEncodeStr[b - 32]);
                }
            }

            return res.ToString();
        }

        public static void AddIfNotExists(this List<string> list, string item)
        {
            if (!list.Contains(item)) list.Add(item);
        }

        public static string[] Add(this string[] array, string item)
        {
            array ??= Array.Empty<string>();
            var list = array.ToList();
            if (!list.Contains(item)) list.Add(item);
            return list.ToArray();
        }

        public static string[] Remove(this string[] array, string item)
        {
            array ??= Array.Empty<string>();
            var list = array.ToList();
            if (list.Contains(item)) list.Remove(item);
            return list.ToArray();
        }

        public static double SameCalcPercent(string data1, string data2)
        {
            var charCnt1 = new int['~' - ' ' + 1];
            var charCnt2 = new int['~' - ' ' + 1];
            data1 = data1.ToUpper();
            data2 = data2.ToUpper();

            var maxLen = Math.Max(data1.Length, data2.Length);

            for (var cnt = 0; cnt < maxLen; cnt++)
            {
                if ((cnt < data1.Length) && (data1[cnt] >= ' ' && data1[cnt] <= '~'))
                {
                    (charCnt1[data1[cnt] - ' '])++;
                }

                if ((cnt < data2.Length) && (data2[cnt] >= ' ' && data2[cnt] <= '~'))
                {
                    (charCnt2[data2[cnt] - ' '])++;
                }
            }

            var diff = 0;
            var total = 0;

            for (var samechar = ' '; samechar < '~'; samechar++)
            {
                if (charCnt1[samechar - ' '] + charCnt2[samechar - ' '] == 0) continue;

                total = total + charCnt1[samechar - ' '] + charCnt2[samechar - ' '];
                diff += Math.Abs(charCnt1[samechar - ' '] - charCnt2[samechar - ' ']);
            }

            return (double)(total - diff) / total * 100.0;
        }

        //https://social.technet.microsoft.com/wiki/contents/articles/26805.c-calculating-percentage-similarity-of-2-strings.aspx
        private static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }

        private static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        public static double SameCalcPercent2(string data1, string data2, bool ignoreCase = true)
        {
            return ignoreCase
                ? CalculateSimilarity(data1.ToUpper(), data2.ToUpper()) * 100
                : CalculateSimilarity(data1, data2) * 100;
        }

        public static bool SameAlmost(this string data1, string data2, int samePercent)
        {
            return SameCalcPercent(data1, data2) >= samePercent;
        }

        public static bool SameAlmost2(this string data1, string data2, int samePercent, bool ignoreCase = true)
        {
            return SameCalcPercent2(data1, data2, ignoreCase) >= samePercent;
        }

        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static bool IsBase64(this string plainText)
        {
            var data = plainText.Base64Decode();
            var reEncode = data.Base64Encode();
            return plainText == reEncode;
        }

        public static string Truncate(this string value, int length)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            if (value.Length > length)
            {
                return value[..length];
            }

            return value;
        }

        public static bool IsNumeric(this string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return false;
            }

            return Int64.TryParse(strValue, out _);
        }

        /// <summary>
        /// Extension version of string.IsNullOrEmpty.
        /// </summary>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string NullIfEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return value;
        }

        public const string DecimalNumbericRegex = @"[^0-9.]";
        public static string NumericCharactersOnly(this string strValue, string defaultRegex = @"[^0-9]")
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                var regex = new Regex(defaultRegex);
                return regex.Replace(strValue, string.Empty);
            }
            return strValue;
        }

        public static string DecimalCharactersOnly(this string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                var regex = new Regex(@"[^0-9.]");
                return regex.Replace(strValue, string.Empty);
            }
            return strValue;
        }

        public static string AlphaCharactersOnly(this string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                var regex = new Regex(@"[^a-zA-Z]");
                return regex.Replace(strValue, string.Empty);
            }
            else return "";
        }

        public static string AlphaNumericCharactersOnly(this string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                var regex = new Regex(@"[^a-zA-Z0-9 ]");
                return regex.Replace(strValue, string.Empty);
            }
            else return strValue;

        }


        public static string FormatWith(this string format, params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            return string.Format(format, args);
        }

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            return string.Format(provider, format, args);
        }

        public static string EncodeTo64(this string toEncode)
        {
            byte[] toEncodeAsBytes

                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;
        }

        public static string RemoveCharacters(this string value, string replaceCharacters, string newValue, bool caseInsensitive = true, bool removeFirsnLast = true)
        {
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(replaceCharacters))
            {
                if (removeFirsnLast)
                    value = value.Trim(replaceCharacters.ToCharArray());
                else
                {
                    foreach (var c in replaceCharacters)
                    {
                        value = value.Replace(c.ToString(), newValue, caseInsensitive);
                    }
                }
            }

            return value;
        }

        public static string Replace(this string value, string replaceValue, string newValue, bool caseInsensitive)
        {
            if (value == null) return null;
            if (replaceValue == null) replaceValue = "";

            if (caseInsensitive)
            {
                var i = value.IndexOf(replaceValue, 0, StringComparison.InvariantCultureIgnoreCase);
                if (i >= 0)
                {
                    var replacing = value.Substring(i, replaceValue.Length);
                    return value.Replace(replacing, newValue);
                }

                return value;
            }
            else
            {
                return value.Replace(replaceValue, newValue);
            }
        }

        /// <summary>
        /// Compare two strings.
        /// </summary>
        /// <param name="thisValue">First string.</param>
        /// <param name="value">Second string.</param>
        /// <param name="comparisonType">Comparison type.</param>
        public static bool Eq(this string thisValue, string value, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            if (string.IsNullOrEmpty(thisValue) && string.IsNullOrEmpty(value)) return true;
            else if (string.IsNullOrEmpty(thisValue) || string.IsNullOrEmpty(value)) return false;
            else return thisValue.Equals(value, comparisonType);
        }

        public static bool ContainsString(this string thisValue, string substring, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            if (string.IsNullOrEmpty(thisValue) && string.IsNullOrEmpty(substring)) return false;
            else if (string.IsNullOrEmpty(thisValue) || string.IsNullOrEmpty(substring)) return false;
            else return thisValue.Contains(substring, comparisonType);
        }

        public static bool ContainsAnyString(this string thisValue, params string[] args)
        {
            foreach (var item in args)
                if (thisValue.ContainsString(item)) return true;
            return false;
        }

        public static bool EqToEnum<TEnum>(this string thisValue, TEnum value)
            where TEnum : struct
        {
            return thisValue.Eq(value.ToString());
        }

        public static bool EqToOneOf(this string thisValue, params string[] args)
        {
            foreach (var item in args)
                if (thisValue.Eq(item)) return true;
            return false;
        }

        public static string PascalCase(this string value, bool multiWords = true)
        {
            if (string.IsNullOrEmpty(value)) return value;
            else
            {
                var sb = new StringBuilder(value);
                for (int i = 0, j = 1; i < sb.Length; i++)
                {
                    var c = sb[i];
                    if (multiWords && (c == ' ' || c == ',' || c == ';' || c == '\'')) j = 1;
                    else if (j == 1)
                    {
                        sb[i] = char.ToUpper(c);
                        j = 0;
                    }
                    else sb[i] = char.ToLower(c);
                }
                return sb.ToString();
            }
        }

        static readonly char[] nameSeparators = new char[] { '-', '\'' };

        public static string NameCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            var values = value.Split(' ');
            var sb = new StringBuilder();
            foreach (var s in values)
            {
                if (sb.Length > 0) sb.Append(' ');
                bool notFirst = false;
                int index, startIndex = 0;
                while (true)
                {
                    index = s.IndexOfAny(nameSeparators, startIndex);
                    if (notFirst && startIndex > 0) sb.Append(s[startIndex - 1]);
                    var p = (index < 0) ? s[startIndex..] : s[startIndex..index];
                    if (p.StartsWith("Mc", StringComparison.CurrentCultureIgnoreCase))
                    {
                        sb.Append("Mc");
                        p = p[2..];
                    }
                    sb.Append(p.PascalCase(false));
                    if (index < 0) break;
                    startIndex = index + 1;
                    notFirst = true;
                }
            }
            return sb.ToString();
        }

        public static string MergeSentence(this IEnumerable<string> values, string title, string glue, string lastGlue)
        {
            if (values == null) return null;
            var sb = new StringBuilder();

            var items = values.ToArray();
            var cnt = 0;
            var total = items.Length;

            foreach (var s in items)
            {
                cnt++;
                if (sb.Length > 0)
                {
                    if (cnt == total && lastGlue != null)
                        sb.Append(lastGlue);
                    else
                        sb.Append(glue);
                }
                sb.Append(s);
            }
            if (sb.Length > 0 && !string.IsNullOrEmpty(title))
                sb.Insert(0, string.Format("{0}{1} ", title, (total > 1) ? "s" : ""));
            return sb.ToString();
        }

        public static string Merge(this IEnumerable<string> values, string glue, string startQuote = null, string endQuote = null, string title = null, bool titleAutoAlteration = true, string lastGlue=null)
        {
            if (values == null) return null;
            var sb = new StringBuilder();

            var items = values.ToArray();
            var cnt = 0;
            var total = items.Length;

            foreach (var s in items)
            {
                cnt++;
                if (sb.Length > 0)
                {
                    if (cnt == total && lastGlue != null)
                        sb.Append(lastGlue);
                    else
                        sb.Append(glue);
                }
                if (startQuote != null) sb.Append(startQuote);
                sb.Append(s);
                if (endQuote != null) sb.Append(endQuote);
            }
            if (sb.Length > 0 && !string.IsNullOrEmpty(title))
                sb.Insert(0, string.Format("{0}{1}: ", title, (titleAutoAlteration && total > 1) ? "s" : ""));
            return sb.ToString();
        }

        public static string MergeWithStyle(this IEnumerable<string> values, string glue, string alternativeGlueForLastPair = null)
        {
            if (values == null) return null;
            var sb = new StringBuilder();
            string v = null;
            foreach (var s in values)
            {
                if (v != null)
                {
                    if (sb.Length > 0) sb.Append(glue);
                    sb.Append(v);
                }
                v = s;
            }
            if (v != null)
            {
                if (sb.Length > 0) sb.Append(alternativeGlueForLastPair ?? glue);
                sb.Append(v);
            }
            return sb.ToString();
        }

        public static string MergeToString<T>(this IEnumerable<T> values, Func<T, string> stringReader, string glue, string startQuote = null, string endQuote = null, string title = null, bool titleAutoAlteration = true)
        {
            if (values == null) return null;
            var strings = (from item in values select stringReader(item));
            return strings.Merge(glue, startQuote, endQuote, title, titleAutoAlteration);
        }

       
    }


}
