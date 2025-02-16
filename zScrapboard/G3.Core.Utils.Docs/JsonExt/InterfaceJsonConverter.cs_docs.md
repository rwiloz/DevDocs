---
title: "InterfaceJsonConverter Class"
description: "Documentation for the InterfaceJsonConverter class in the G3.Core.Utils.JsonExt namespace."
date: 2023-10-10
draft: false
---

# InterfaceJsonConverter Class

This documentation provides details about the `InterfaceJsonConverter` class, its methods, and its functionality. The class allows WebAPI to construct interfaces without the need to define a concrete class.

## Namespace

`G3.Core.Utils.JsonExt`

## Assembly

Specify the assembly where this class is implemented (if applicable).

## Summary

The `InterfaceJsonConverter` class is a custom JSON converter tailored for interface instantiation through AutoMapper proxy generation, facilitating JSON operations without predefined concrete classes.

## Code

```csharp
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using Newtonsoft.Json;

namespace G3.Core.Utils.JsonExt
{
    /// <summary>
    /// This json converter allows WebAPI to construct Interfaces without needing to define a concrete class.
    /// </summary>
    public class InterfaceJsonConverter : JsonConverter
    {
        private readonly IMapper mapper;
        private readonly IEnumerable<Type> interfaces;

        public InterfaceJsonConverter(IEnumerable<Type> interfaces)
        {
            this.interfaces = interfaces;

            // Create a Mapping for each interface, which generates an internal proxy type for each.
            var cfg = new MapperConfigurationExpression();
            foreach (var i in interfaces)
            {
                cfg.CreateMap(typeof(ExpandoObject), i);
            }

            var mapperConfig = new MapperConfiguration(cfg);
            mapper = new Mapper(mapperConfig);
        }

        public override bool CanConvert(Type objectType)
        {
            return (interfaces.Contains(objectType));
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanWrite
        {
            get
            {
                // We aren't overriding the Write Json functionality. That works fine with interfaces.
                return false;
            }
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // We aren't overriding the Write Json functionality. That works fine with interfaces.
            throw new NotImplementedException();
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // We are using AutoMapper here purely to create a dynamic type. It will have null values for all the properties.
            var returnObj = mapper.Map(new ExpandoObject(), typeof(ExpandoObject), objectType);

            // We then use Json.Net to populate all those properties.
            serializer.Populate(reader, returnObj);

            return returnObj;
        }
    }
}
```

## Constructor

### InterfaceJsonConverter(IEnumerable<Type> interfaces)

Creates an instance of the `InterfaceJsonConverter` class.

- **Parameters:**
  - `IEnumerable<Type> interfaces`: A collection of interfaces to be mapped using AutoMapper.

## Methods

### CanConvert(Type objectType)

Determines if the converter can convert the specified object type.

- **Parameters:**
  - `Type objectType`: The type of the object.
- **Returns:** `bool`: `true` if the object type is contained within the interfaces; otherwise, `false`.

### ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)

Reads the JSON representation of the object.

- **Parameters:**
  - `JsonReader reader`: The JSON reader.
  - `Type objectType`: The type of the object.
  - `object existingValue`: The existing value of the object being read.
  - `JsonSerializer serializer`: The serializer calling this method.
- **Returns:** `object`: The populated object value.

### WriteJson(JsonWriter writer, object value, JsonSerializer serializer)

Throws a `NotImplementedException` as writing JSON is not overridden.

- **Parameters:**
  - `JsonWriter writer`
  - `object value`
  - `JsonSerializer serializer`

## Properties

### CanRead

- **Type:** `bool`
- **Description:** Determines whether this `JsonConverter` can read JSON. Always returns `true`.

### CanWrite

- **Type:** `bool`
- **Description:** Determines whether this `JsonConverter` can write JSON. Always returns `false`.

---

For more information, check the official documentation or contact the development team for queries related to this converter implementation.
```