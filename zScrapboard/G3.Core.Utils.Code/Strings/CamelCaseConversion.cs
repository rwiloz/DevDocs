Here's your code with inline XML summary comments:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace G3.Core.Utils.Strings
{
    /// <summary>
    /// Static class to handle camel case conversions
    /// </summary>
    public static class CamelCaseConversion
    {
        /// <summary>
        /// Converts a camel case string to title case. 
        /// </summary>
        /// <param name="text">The camel case text to convert</param>
        /// <returns>A title case version of the input string</returns>
        public static string CamelToTitleCase(this string text)
        {
            // ...
        }

        /// <summary>
        /// Converts a camel case string to title case considering an array of acronyms.
        /// </summary>
        /// <param name="text">The camel case text to convert</param>
        /// <param name="acroynoms">The array of acronyms to consider for the conversion</param>
        /// <returns>A title case version of the input string</returns>
        public static string CamelToTitleCase(this string text, string[] acroynoms)
        {
            // ...
        }

        /// <summary>
        /// Capitalises the first character of every word in a sentence.
        /// </summary>
        /// <param name="sentence">The sentence to capitalise</param>
        /// <returns>The input string with each word's first character capitalised</returns>
        public static string CapitaliseFirstCharacterSentence(this string sentence)
        {
            // ...
        }

        /// <summary>
        /// Capitalises the first character of a string.
        /// </summary>
        /// <param name="text">The string to capitalise</param>
        /// <returns>The string with the first character capitalised</returns>
        public static string CapitaliseFirstCharacter(this string text)
        {
            // ...
        }

        /// <summary>
        /// Makes the first character of the string lowercase.
        /// </summary>
        /// <param name="text">The string to modify</param>
        /// <returns>The string with the first character made lowercase</returns>
        public static string LowerFirstCharacter(string text)
        {
            // ...
        }
    }
}
```

These summary comments will appear when you hover over a method in an IDE that supports XML summary comments. They are also used to generate documentation for the code.