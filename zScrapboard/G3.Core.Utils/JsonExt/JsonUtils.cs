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
    public static class JsonUtils
    {
        public static JsonSerializerSettings JsonSettings => new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            //PreserveReferencesHandling = PreserveReferencesHandling.Objects, //doesn't work properly
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public static JsonSerializerSettings JsonSettingsSerializeAll => new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Include,
            NullValueHandling = NullValueHandling.Include,
            //PreserveReferencesHandling = PreserveReferencesHandling.Objects, //doesn't work properly
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

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
                    //DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                    //DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffZ", causes issues by cuttin off time zone
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                config.Converters.Add(new StringEnumConverter());
                //config.Converters.Add(new DictionaryKeysAreNotPropertyNamesJsonConverter());

                return config;
            }
        }

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
                    //DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                    //DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffZ", causes issues by cuttin off time zone
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                config.Converters.Add(new StringEnumConverter());
                //config.Converters.Add(new DictionaryKeysAreNotPropertyNamesJsonConverter());

                return config;
            }
        }

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
                    //DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                    //DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffZ", causes issues by cuttin off time zone
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                config.Converters.Add(new StringEnumConverter());
                //config.Converters.Add(new DictionaryKeysAreNotPropertyNamesJsonConverter());

                return config;
            }
        }

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
                //config.Converters.Add(new DictionaryKeysAreNotPropertyNamesJsonConverter());

                return config;
            }
        }
    }
}
