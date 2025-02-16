Here's your code with inline XML summary comments:

```Csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace G3.Core.Utils.JsonExt
{
    /// <summary>
    /// This class defines methods for masking json fields.
    /// </summary>
    /// <remarks> Original source code: https://github.com/ThiagoBarradas/jsonmasking/blob/master/JsonMasking/JsonMasking.cs </remarks>
    public static class JsonMask
    {
        /// <summary>
        /// Mask specified fields in a JSON string.
        /// </summary>
        /// <param name="json">The JSON to mask properties in.</param>
        /// <param name="blackListPath">Array of properties to mask.</param>
        /// <param name="maskValues">Array of regular expressions to match against property values.</param>
        /// <param name="mask">The mask to replace property values with.</param>
        /// <returns>The JSON string with masked fields.</returns>
        /// <exception cref="ArgumentNullException">Thrown when null is passed to any argument.</exception>
        public static string JsonMaskFields(this string json, string[] blackListPath, string[] maskValues, string mask)
        {
            // omitted for brevity 
        }

        /// <summary>
        /// Recursively masks fields in a JToken and its children.
        /// </summary>
        /// <param name="token">The JToken to mask properties in.</param>
        /// <param name="blackListPath">Array of properties to mask.</param>
        /// <param name="maskValues">Array of regular expressions to match against property values.</param>
        /// <param name="mask">The mask to replace property values with.</param>
        private static void MaskFieldsFromJToken(JToken token, string[] blackListPath, string[] maskValues, string mask)
        {
            // omitted for brevity 
        }
    }
}
```

I've added summary comments for the class and its two methods, along with params for all the parameters. I've also included exception comments for the exceptions that can be thrown by the `JsonMaskFields` method.