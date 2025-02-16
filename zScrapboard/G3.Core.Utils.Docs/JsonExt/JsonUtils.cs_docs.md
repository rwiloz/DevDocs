```
---
title: "JsonUtils Class Documentation"
date: 2023-10-03
draft: false
tags: ["Json", "Serialization", "C#", "Newtonsoft.Json"]
---

# JsonUtils Class

The `JsonUtils` class in the `G3.Core.Utils.JsonExt` namespace provides a collection of predefined `JsonSerializerSettings`. These settings are useful for customizing how JSON data is serialized and deserialized using the Newtonsoft.Json library. The class includes several static properties to cater to different serialization needs.

## Namespaces

To use the `JsonUtils` class, the following namespaces are required:

```csharp
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
```

## JsonSerializerSettings Properties

### JsonSettings

```csharp
public static JsonSerializerSettings JsonSettings => new JsonSerializerSettings
{
    DefaultValueHandling = DefaultValueHandling.Ignore,
    NullValueHandling = NullValueHandling.Ignore,
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
};
```

- **DefaultValueHandling**: Ignores default values when serializing.
- **NullValueHandling**: Ignores null values when serializing.
- **ReferenceLoopHandling**: Ignores reference loops, preventing infinite serialization loops.

### JsonSettingsSerializeAll

```csharp
public static JsonSerializerSettings JsonSettingsSerializeAll => new JsonSerializerSettings
{
    DefaultValueHandling = DefaultValueHandling.Include,
    NullValueHandling = NullValueHandling.Include,
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
};
```

- **DefaultValueHandling**: Includes default values in serialization.
- **NullValueHandling**: Includes null values in serialization.

### JsonSettingsJavaScript

```csharp
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
```

- **ContractResolver**: Uses camel case naming for properties.
- **DateTimeZoneHandling**: Handles date and time in UTC format.
- **Converters**: Includes a converter for string enums.

### JsonSettingsJavaScriptIgnoreNulls

```csharp
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
```

- **NullValueHandling**: Ignores null values while all other settings mirror those in `JsonSettingsJavaScript`.

### JsonSettingsJavaScriptSerializeAll

```csharp
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
```

- Includes both default and null values, suitable for exhaustive JSON serialization needs.

### JsonSettingsSwagger

```csharp
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
```

- **DateFormatString**: Uses a specific format for date and time serialization.
- Suitable for Swagger-related JSON serialization needs.

## Conclusion

The `JsonUtils` class equips developers with various `JsonSerializerSettings` configurations, catering to a wide range of JSON serialization scenarios with the Newtonsoft.Json library. Adjust these settings as needed to tailor the JSON output for your applications.