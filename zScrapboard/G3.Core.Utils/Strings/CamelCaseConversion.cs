using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace G3.Core.Utils.Strings
{
    public static class CamelCaseConversion
    {
        public static string CamelToTitleCase(this string text)
        {
            //if (string.IsNullOrEmpty(text))
            //{
            //    return string.Empty;
            //}

            //text = text.Substring(0, 1).ToUpper() + text.Substring(1);
            //return Regex.Replace(text, @"(\B[A-Z])", @" $1");
            if (string.IsNullOrEmpty(text)) return string.Empty;

            StringBuilder sb = new StringBuilder(text.Length * 2);
            var upperCaseSequence = 0;
            int lastIndex = text.Length - 2;
            for (int i = 0; i <= lastIndex; i++)
            {
                var currentChar = text[i];
                var nextChar = text[i + 1];
                var currentIsLowerCase = (char.ToLower(currentChar) == currentChar);
                var nextIsLowerCase = (char.ToLower(nextChar) == nextChar);

                if (currentIsLowerCase) upperCaseSequence = 0;
                else upperCaseSequence++;

                if (currentIsLowerCase && !nextIsLowerCase) sb.Append(currentChar).Append(' ');
                else if (!currentIsLowerCase && nextIsLowerCase && upperCaseSequence > 1) sb.Append(' ').Append(currentChar);
                else sb.Append(currentChar);
            }
            return sb.Append(text[lastIndex + 1]).ToString();
        }

        public static string CamelToTitleCase(this string text, string[] acroynoms)
        {
            List<string> capitalise = new List<string>();
            foreach (var a in acroynoms)
            {
                var cap = CapitaliseFirstCharacter(a);
                capitalise.Add(cap);
                text = text.Replace(a, cap);
            }

            text = text.Substring(0, 1).ToUpper() + text.Substring(1);
            text = Regex.Replace(text, @"(\B[A-Z])", @" $1");

            foreach (var a in capitalise)
            {
                text = text.Replace(a, a.ToUpper());
            }

            return text;
        }

        public static string CapitaliseFirstCharacterSentence(this string sentence)
        {
            var result = sentence;
            if (!string.IsNullOrEmpty(sentence))
            {
                var words = sentence.Split(' ');
                var sb = new StringBuilder();
                for (var i = 0; i < words.Length; i++)
                {
                    if ((i > 0) && (i != (words.Length - 1)))
                    {
                        sb.Append(" ");
                    }
                    sb.Append(CapitaliseFirstCharacter(words[i]));
                }
                result = sb.ToString();
            }

            return result;
        }
        public static string CapitaliseFirstCharacter(this string text)
        {
            // TODO find better way
            if (!string.IsNullOrEmpty(text))
            {
                text = char.ToUpper(text[0]) + text.ToLower().Substring(1);
            }

            return text;
        }


        /// <summary>
        /// Makes the first character of the string lowercase
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string LowerFirstCharacter(string text)
        {
            // TODO find better way
            if (!string.IsNullOrEmpty(text))
            {
                text = char.ToLower(text[0]) + text.Substring(1);
            }

            return text;
        }
    }
}
