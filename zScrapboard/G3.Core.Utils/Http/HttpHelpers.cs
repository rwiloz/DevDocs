using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Http
{
    public static class HttpHelpers
    {
        public static string CheckAddUtf8(this string contentType)
        {
            var textTypes = new string[]
            {
                "text/html",
                "application/javascript",
                "application/json",
                "text/css",
                "application/manifest+json",
                "image/svg+xml"
            };

            if (textTypes.Contains(contentType)) return $"{contentType}; charset=utf-8";

            return contentType;
        }
    }
}
