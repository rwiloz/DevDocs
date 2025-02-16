Sure, here is your code with inline XML summary comments:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Http
{
    /// <summary>
    /// Static class that contains Http related helper methods.
    /// </summary>
    public static class HttpHelpers
    {
        /// <summary>
        /// Checks and adds UTF-8 encoding to the content type if pertinent.
        /// </summary>
        /// <param name="contentType">The HTTP content type.</param>
        /// <returns>Returns the adjusted content type with UTF-8 if it fits the criteria, or the original content type otherwise.</returns>
        public static string CheckAddUtf8(this string contentType)
        {
            //List of media types that should use UTF-8 encoding.
            var textTypes = new string[]
            {
                "text/html",
                "application/javascript",
                "application/json",
                "text/css",
                "application/manifest+json",
                "image/svg+xml"
            };

            //Check if content type is of a text type, if so add UTF-8 encoding to the content type.
            if (textTypes.Contains(contentType)) return $"{contentType}; charset=utf-8";

            //If content type is not a text type, return the original.
            return contentType;
        }
    }
}
```

The XML summary comments above provide a high-level overview of the class and method, which can be very useful when maintaining or updating the code in future.