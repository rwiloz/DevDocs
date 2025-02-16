Here's the code with XML summary comments:

```C#
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.JsonExt
{
    /// <summary>
    /// Utility class for JSON utility methods
    /// </summary>
    public static class JsonUtils
    {
        /// <summary>
        /// Gets the default Json Serializer Settings
        /// </summary>
        public static JsonSerializerSettings JsonSettings => new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        /// <summary>
        /// Gets JsonSerializerSettings that includes all properties while serializing
        /// </summary>
        public static JsonSerializerSettings JsonSettingsSerializeAll => new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Include,
            NullValueHandling = NullValueHandling.Include,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        /// <summary>
        /// Gets JsonSerializerSettings intended for JavaScript serialization
        /// </summary>
        public static JsonSerializerSettings JsonSettingsJavaScript
        {
            get
            {
                var config = new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Include,
                    Formatting = Formatting.None,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                config.Converters.Add(new StringEnumConverter());

                return config;
            }
        }

        /// <summary>
        /// Gets JsonSerializerSettings for JavaScript serialization but ignores nulls
        /// </summary>
        public static JsonSerializerSettings JsonSettingsJavaScriptIgnoreNulls
        {
            get
            {
                var config = new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Include,
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.None,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                config.Converters.Add(new StringEnumConverter());

                return config;
            }
        }

        /// <summary>
        /// Gets JsonSerializerSettings for JavaScript that includes all properties while serializing
        /// </summary>
        public static JsonSerializerSettings JsonSettingsJavaScriptSerializeAll
        {
            get
            {
                var config = new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Include,
                    NullValueHandling = NullValueHandling.Include,
                    Formatting = Formatting.None,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                config.Converters.Add(new StringEnumConverter());

                return config;
            }
        }

        /// <summary>
        /// Gets JsonSerializerSettings intended for use with Swagger
        /// </summary>
        public static JsonSerializerSettings JsonSettingsSwagger
        {
            get
            {
                var config = new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Include,
                    Formatting = Formatting.None,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff",
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                };

                config.Converters.Add(new StringEnumConverter());

                return config;
            }
        }
    }
}
```

Each property and method signature now has a short summary comment describing its purpose and intended use.