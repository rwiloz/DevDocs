---
title: "JsonArrayConverter Class"
date: 2023-10-01
description: "Documentation for the JsonArrayConverter class, a custom JSON converter that handles deserialization of JSON arrays using Newtonsoft.Json."
draft: false
---

# JsonArrayConverter\<T\> Class

The `JsonArrayConverter<T>` class is a custom JSON converter that extends `JsonConverter` to handle deserialization of JSON arrays. It is part of the `G3.Core.Utils.JsonExt` namespace and uses the Newtonsoft.Json library.

## Namespace

`G3.Core.Utils.JsonExt`

## Inheritance

- System.Object
  - Newtonsoft.Json.JsonConverter
    - G3.Core.Utils.JsonExt.JsonArrayConverter\<T\>

## Syntax

```csharp
public class JsonArrayConverter<T> : JsonConverter
```

## Type Parameters

- `T`: The type of the objects in the JSON array.

## Constructors

- `JsonArrayConverter<T>()`: Initializes a new instance of the `JsonArrayConverter<T>` class.

## Methods

### CanConvert

```csharp
public override bool CanConvert(Type objectType)
```

Determines whether the converter can handle the specified object type.

- **Parameters**: 
  - `objectType` (Type): The type of the object to check.
- **Returns**: `bool` - `true` if the object is of type `List<T>`; otherwise, `false`.

### ReadJson

```csharp
public override object ReadJson(
    JsonReader reader,
    Type objectType,
    object existingValue,
    JsonSerializer serializer)
```

Reads the JSON representation of the object.

- **Parameters**: 
  - `reader` (JsonReader): The `JsonReader` to read from.
  - `objectType` (Type): The type of the object.
  - `existingValue` (object): The existing value of the object being read.
  - `serializer` (JsonSerializer): The calling serializer.
- **Returns**: `object` - A deserialized object of type `List<T>`. If the JSON token is not an array, returns a list with a single deserialized object of type `T`.

### CanWrite

```csharp
public override bool CanWrite { get; }
```

Gets a value indicating whether this `JsonConverter` can write JSON. This converter can only read JSON, so it returns `false`.

### WriteJson

```csharp
public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
```

Throws a `NotImplementedException` since writing JSON is not supported by this converter.

- **Parameters**: 
  - `writer` (JsonWriter): The `JsonWriter` to write to.
  - `value` (object): The value to write.
  - `serializer` (JsonSerializer): The calling serializer.
- **Exceptions**: 
  - `NotImplementedException`: This is always thrown as writing is not implemented.

## Example

```csharp
// Example usage of JsonArrayConverter<T> can be added here if necessary
```

This converter is specifically designed to handle the conversion of JSON arrays into `List<T>` objects, providing developers with flexibility when dealing with dynamic JSON data structures.
```