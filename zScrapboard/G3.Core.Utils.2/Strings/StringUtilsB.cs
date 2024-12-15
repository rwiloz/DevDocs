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
   
        public static string ToMaskedValue(this string value, int leftVisible, char maskSymbol = '*')
        {
            if (string.IsNullOrEmpty(value)) return null;
            var sb = new StringBuilder(value);
            var endAt = sb.Length - leftVisible;
            for (int i = 0; i < endAt; i++)
                sb[i] = maskSymbol;
            return sb.ToString();
        }

        public static string MaskMobile(this string mobile)
        {
            return mobile.ToMaskedValue(3);
        }

        public static string MaskMobileAu(this string mobile)
        {
            if (mobile.IsNullOrEmpty() || mobile.Length < 5) return mobile;
            return mobile[..2] + mobile[2..].MaskMobile();
        }

        private static int MaxChars(int maxCount, int count)
        {
            return count > maxCount ? maxCount : count;
        }

        private static string MaskWord(string word)
        {
            if (word.IsNullOrEmpty() || word.Length < 3 || word == "com") return word;

            if (word.Length > 10)
                return word[..3].PadRight(MaxChars(7, word.Length - 3), '*') + word.Substring(word.Length - 3, 3);

            if (word.Length > 6)
                return word[..2].PadRight(MaxChars(6, word.Length - 2), '*') + word.Substring(word.Length - 2, 2);

            return word[..1].PadRight(word.Length - 1, '*') + word.Substring(word.Length - 1, 1);
        }

        public static string MaskEmail(this string email)
        {
            if (email.IsNullOrEmpty()) return email;

            var bits = email.Split("@");
            if (bits.Length != 2) return "*InvalidEmail*";

            var res = MaskWord(bits[0]);
            res += "@";

            var domainBits = bits[1].Split(".");
            for (var i = 0; i < domainBits.Length; i++)
            {
                if (i < domainBits.Length - 1) 
                    res += MaskWord(domainBits[i]) + ".";
                else
                    res += domainBits[i];
            }

            return res;
        }

        public static string GetString(this string value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value;
        }

        public static string GetStringDefault(this string value, string defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return value;
        }

        public static string GetTrimString(this string value)
        {
            return GetString(value).Trim();
        }

        public static string MaxLength(this string input, int maxLength)
        {
            if (input == null || input.Length < maxLength) return input;
            return input[..maxLength];
        }

        public static string GetAsciiString(this string value, string replacementString = "")
        {
            return Encoding.ASCII.GetString(
                Encoding.Convert(
                    Encoding.UTF8,
                    Encoding.GetEncoding(
                        Encoding.ASCII.EncodingName,
                        new EncoderReplacementFallback(replacementString),
                        new DecoderExceptionFallback()
                    ),
                    Encoding.UTF8.GetBytes(value)
                )
            );
        }

        public static string GetAsciiTrimString(this string value, string replacementString = "")
        {
            return GetAsciiString(value, replacementString).GetTrimString();

        }

        public static string ToFriendlyString<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, Func<TKey, string> keyToString = null, Func<TValue, string> valueToString = null)
        {
            string key;
            if (default(TKey) == null)
            {
                if (Comparer<TKey>.Default.Compare(kvp.Key, default) == 0) key = "";
                else if (keyToString == null) key = kvp.Key.ToString();
                else key = keyToString(kvp.Key);
            }
            else if (keyToString == null) key = kvp.Key.ToString();
            else key = keyToString(kvp.Key);

            string value;
            if (default(TValue) == null)
            {
                if (Comparer<TValue>.Default.Compare(kvp.Value, default) == 0) value = "";
                else if (valueToString == null) value = kvp.Value.ToString();
                else value = valueToString(kvp.Value);
            }
            else if (valueToString == null) value = kvp.Value.ToString();
            else value = valueToString(kvp.Value);

            if (key.Eq(value)) return key;
            else return "{0} - {1}".FormatWith(key, value);
        }

        public static TEnum? AsEnum<TEnum>(this string value)
            where TEnum : struct
        {
            if (string.IsNullOrEmpty(value)) return null;
            else return (TEnum)Enum.Parse(typeof(TEnum), value);
        }

        public static string GetInitials(this string value)
        {
            if (value == null)
                return null;

            string[] words = value.Split(' ');
            return new string(words.Select(word => word[0]).ToArray()).ToUpper();
        }

        /// <summary>
        /// Randomly generate string using characters from provided string.
        /// </summary>
        /// <param name="value">Source for characters.</param>
        /// <param name="maxLength">Max length for result string.</param>
        /// <param name="allowRepetitions">Allow to reuse characters from source string.</param>
        /// <returns></returns>
        public static string ShuffleAndDraw(this string value, int maxLength, bool allowRepetitions = false)
        {
            var set = new List<char>(value.ToArray());
            var result = new StringBuilder(maxLength);
            var random = RandomNumberGenerator.Create(); // create cryptographic random number generator
            var buffer = new byte[maxLength * 4]; // getting a buffer which contains maxLength 32-bit numbers
            random.GetBytes(buffer);

            for (int i = 0; i < maxLength; i++)
            {
                if (set.Count == 0) throw new IndexOutOfRangeException("Not enought characters to build a string");

                var index = Math.Abs(BitConverter.ToInt32(buffer, i * 4)) % set.Count; // convert each 4 bytes to an integer and mod it by count
                result.Append(set[index]);

                if (!allowRepetitions) set.RemoveAt(index); // remove used character
            }
            return result.ToString();
        }

        public static void Suffle<T>(this T[] values, byte[] seed = null)
        {
            if (seed == null)
            {
                var random = RandomNumberGenerator.Create(); // create cryptographic random number generator
                seed = new byte[values.Length * 4]; // getting a buffer which contains maxLength 32-bit numbers
                random.GetBytes(seed);
            }

            for (int i = 0; i < values.Length; i++)
            {
                var index = Math.Abs(BitConverter.ToInt32(seed, i * 4)) % values.Length; // convert each 4 bytes to an integer and mod it by count
                var prev = values[i];
                values[i] = values[index];
                values[index] = prev;
            }
        }

        /// <summary>
        /// Randomly generate string using characters from provided string.
        /// </summary>
        /// <param name="value">Source for characters.</param>
        /// <param name="maxLength">Max length for result string.</param>
        /// <param name="allowRepetitions">Allow to reuse characters from source string.</param>
        /// <returns></returns>
        public static string ShuffleAndDraw(this IEnumerable<string> value, int maxLength, bool allowRepetitions = false)
        {
            var alphabets = value.Select(x => new List<char>(x.ToArray())).ToList();
            var result = new StringBuilder(maxLength);
            var random = RandomNumberGenerator.Create(); // create cryptographic random number generator
            var buffer = new byte[maxLength * 4]; // getting a buffer which contains maxLength 32-bit numbers
            random.GetBytes(buffer);

            // contain index of the alphabet for each letter
            var alphabetIndexes = new int[maxLength];
            // equal distribution
            for (var i = 0; i < maxLength; i++) alphabetIndexes[i] = i % alphabets.Count;
            alphabetIndexes.Suffle(buffer);

            for (var i = 0; i < maxLength; i++)
            {
                if (alphabets.Count == 0) throw new IndexOutOfRangeException("Not enought characters to build a string");

                var index = Math.Abs(BitConverter.ToInt32(buffer, i * 4)); // convert each 4 bytes to an integer
                // get alphabet no
                var alphabetIndex = alphabetIndexes[i] % alphabets.Count;
                var alphabet = alphabets[alphabetIndex];
                // pick random letter
                var letterIndex = index % alphabet.Count;
                result.Append(alphabet[letterIndex]);

                if (!allowRepetitions)
                {
                    alphabet.RemoveAt(letterIndex); // remove used character
                    if (alphabet.Count == 0) alphabets.RemoveAt(alphabetIndex);
                }
            }
            return result.ToString();
        }

        public static bool SplitAndContains(this string value, string splitter, string element, IEqualityComparer<string> equalityComparer = null)
        {
            if (string.IsNullOrEmpty(value)) return false;

            var keys = value.Split(new[] { splitter }, StringSplitOptions.RemoveEmptyEntries).ToHashSet(equalityComparer);
            return keys.Contains(element);
        }

        /// <summary>
        /// Formats a number by replace # with the number in the value list
        /// eg ### ## given 12345 gives 123 45
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string FormatNumber(this string value, string format)
        {
            var result = value;
            if (!string.IsNullOrEmpty(value) &&
                !string.IsNullOrEmpty(format))
            {
                int i = 0;
                var sb = new StringBuilder();
                foreach (var c in format)
                {
                    if (i >= value.Length)
                    {
                        break;
                    }
                    if (c != '#')
                    {
                        sb.Append(c);
                    }
                    else
                    {
                        sb.Append(value[i]);
                        i++;
                    }
                }
                result = sb.ToString();
            }

            return result;
        }

        public static int IndexOfLastChar(string value, char separator)
        {
            if (string.IsNullOrEmpty(value))
            {
                return -1;
            }

            for (int i = (value.Length - 1); i >= 0; i--)
            {
                if (value[i] == separator)
                {
                    return i;
                }
                else if (char.IsWhiteSpace(value[i]))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            return -1;
        }

        public static string StripLastChar(string value, char separator)
        {
            var index = IndexOfLastChar(value, separator);
            if (index >= 0)
            {
                return value[..index];
            }

            return value;
        }

        /// <summary>
        /// Removes the last char if it matches the character
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        public static string RemoveLastCharIs(string value, char character)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var index = value.LastIndexOf(character);
                if ((value.Length > 0) && (value.Length == (index + 1)))
                {
                    value = value[..index];
                }
            }
            return value;
        }

        /// <summary>
        /// Removes the last char if it matches the character
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        public static string InsertLastChar(string value, char character)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var index = value.LastIndexOf(character);
                if (index < 0)
                {
                    value += character;
                }
            }

            return value;
        }

        public static string ListToString(IEnumerable<string> values, char separator)
        {
            var result = new StringBuilder();
            foreach (var v in values)
            {
                if (result.Length > 0) result.Append(separator);
                result.Append(v);
            }
            return result.ToString();
        }


        public static string ListToString(this IEnumerable<string> values, string separator)
        {
            var result = new StringBuilder();
            foreach (var v in values)
            {
                if (result.Length > 0) result.Append(separator);
                result.Append(v);
            }
            return result.ToString();
        }

        public static List<string> StringToList(this string values, char separator = ',')
        {
            var list = new List<string>();
            if (!string.IsNullOrEmpty(values))
            {
                foreach (var f in values.Split(separator))
                {
                    if (!string.IsNullOrEmpty(f))
                    {
                        list.Add(f);
                    }
                }
            }

            return list;
        }

        public static string ReplaceSpecialChars(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                // TODO: get from DB like SiteShield/Credentials
                // ImportContent/SpecialChars
                var charMap = new Dictionary<string, string>
                {
                    {"™", "&trade;"}, {"'", "&#39;"}, {"–", "&ndash;"}, {"-", "&dash;"}, {"%", "&percnt;"},
                    {"“", "&quot;"}, {"é", "&eacute;"}, {"É", "&Eacute;"}, {"’", "&rsquo;"}, {"‘", "&lsquo; "},
                    {"U+000C9", "&Eacute;"}
                };

                foreach (var c in charMap)
                {
                    value = value.Replace(c.Key, c.Value);
                }
            }

            return value;
        }

        private static string MaskCard(string str, Match cardMatch)
        {
            var ch = str.ToCharArray();
            var pos = cardMatch.Index;
            var regex09 = new Regex(@"[\-0-9]{3}");
            bool more;
            do
            {
                if (str.Length <= pos + 3)
                {
                    break;
                }

                var match = regex09.Match(str.Substring(pos + 1, 3));
                more = match.Success;
                if (pos > cardMatch.Index + 2 && more && ch[pos] >= '0' && ch[pos] <= '9')
                {
                    ch[pos] = 'X';
                }

                pos++;
            } while (more);

            return new string(ch);
        }

        public static string RemoveCardNumbers(this string str)
        {
            var regex = new Regex(@"[0-9]{3}[ \-0-9]{11}");
            var matchFnd = regex.Match(str);

            while (matchFnd.Success)
            {
                str = MaskCard(str, matchFnd);
                matchFnd = regex.Match(str);
            }

            return str;
        }

        public static string EncodeNonAsciiCharacters(this string value)
        {
            var sb = new StringBuilder();
            foreach (var c in value)
            {
                if (c > 127)
                {
                    // This character is too big for ASCII
                    var encodedValue = "\\u" + ((int)c).ToString("x4");
                    sb.Append(encodedValue);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string DecodeEncodedNonAsciiCharacters(this string value)
        {
            return Regex.Replace(
                value,
                @"\\u(?<Value>[a-zA-Z0-9]{4})",
                m => ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString());
        }
    }


}
