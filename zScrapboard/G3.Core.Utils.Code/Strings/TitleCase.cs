The comments are added below:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Strings
{
    /// <summary>
    /// Static class StringTitle used to provide extension methods for working with Strings.
    /// </summary>
    public static class StringTitle
    {
        /// <summary>
        /// Converts the given string to title case string.
        /// Special cases ("Mc", "Mac") are handled separately. 
        /// Also, title cased are characters after specified symbols and digits.
        /// </summary>
        /// <param name="value">The string to convert to title case.</param>
        /// <returns>The title cased string. If the string is null, the return value is null.</returns>
        public static string TitleCase(this string value)
        {
            if (value == null) return null;
            int cnt;
            var sb = new StringBuilder();
            var b = value.ToCharArray();
            var cap = true;
            for (cnt = 0; cnt < b.Length; cnt += 1)
            {
                sb.Append(cap ? char.ToUpper(b[cnt]) : char.ToLower(b[cnt]));

                cap = b[cnt] == ' ';
                if ((sb.Length > 1) && (sb.ToString().Substring(sb.Length - 2, 2) == "Mc")) cap = true;
                if ((sb.Length > 2) && (sb.ToString().Substring(sb.Length - 3, 3) == "Mac")) cap = true;
                if (sb.Length > 0)
                {
                    var last = sb[sb.Length - 1];
                    if (last == '(') cap = true;
                    if (last == '-') cap = true;
                    if (last == '`') cap = true;
                    if (last == '&') cap = true;
                    if (last == '"') cap = true;
                    if (last == '\'') cap = true;
                    if (last == '.') cap = true;
                    if (last >= '0' && last <= '9') cap = true;
                }
            }

            var res = sb + " ";

            res = res
                .Replace("'S ", "'s ")
                .Replace("`S ", "'s ")
                .Trim();

            return res;
        }
    }
}
```
With XML documentation comments, you document your code directly in your source files, by creating a special kind of comment, stripped down XML. This helps your colleagues or clients to understand the code processes which you have used to perform functionalities. In a large code base, it can be extremely useful.