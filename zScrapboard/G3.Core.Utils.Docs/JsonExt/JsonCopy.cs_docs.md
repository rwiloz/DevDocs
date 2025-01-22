---
title: JsonCopy Utility
description: Documentation for the JsonCopy utility in the G3.Core.Utils.JsonExt namespace.
date: 2023-10-05
---

# JsonCopy Utility

The `JsonCopy` utility provides a mechanism to create deep copies of objects through JSON serialization and deserialization. This approach uses the `Newtonsoft.Json` library to ensure that all nested objects are also copied, which can be particularly useful for complex object graphs.

## Namespace

`G3.Core.Utils.JsonExt`

## Code Details

### Class: `JsonCopy`

The `JsonCopy` class is a static utility class that contains methods to facilitate the deep copying of objects.

#### Method: `Copy<TDest>`

Creates a deep copy of an object by serializing and then deserializing it using JSON. This method is generic and can copy objects to any specified type that is compatible with the source object.

**Signature:**

```csharp
public static TDest Copy<TDest>(object src) where TDest :  class
```

**Type Parameters:**

- `TDest`: The destination type to which the object should be copied. This type must be a reference type (`class`).

**Parameters:**

- `src`: An `object` representing the source object to be copied.

**Returns:**

- Returns an object of type `TDest` that is a deep copy of the source object.

**Dependencies:**

- `Newtonsoft.Json.JsonConvert`: Used to perform the serialization and deserialization.
- `JsonUtils.JsonSettings`: Configuration settings for JSON serialization and deserialization, assumed to be defined elsewhere.

### Example Usage

```csharp
var originalObject = new SomeClass { Property1 = "Value", Property2 = 42 };
var copiedObject = JsonCopy.Copy<SomeClass>(originalObject);
```

In this example, `SomeClass` must be a class with properties that can be serialized using the specified JSON settings.

### Remarks

The `Copy` method is useful in scenarios where you want to ensure that the original object and the copied object do not share any references to the same objects in memory. By using JSON serialization, changes to the copied object's properties do not affect the original object.

Ensure that the objects involved are fully compatible with the JSON serialization process, handling cases where certain properties might need custom converters.

## References

- [Newtonsoft.Json Documentation](https://www.newtonsoft.com/json/help/html/N_Newtonsoft_Json.htm)
- [Microsoft Writing Style Guide](https://learn.microsoft.com/en-us/style-guide/welcome/)
```