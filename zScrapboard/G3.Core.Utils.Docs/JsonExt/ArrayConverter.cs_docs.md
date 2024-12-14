# JsonArrayConverter Class

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace G3.Core.Utils.JsonExt
{
    public class JsonArrayConverter<T> : JsonConverter
    {
        ...
    }
}
```

The `JsonArrayConverter` class is a custom converter that is used to control the serialization of a specific type of object (in this case, generic List<T>) to and from JSON. This class inherits from `JsonConverter` which exists in the `Newtonsoft.Json` namespace.

## Methods

### CanConvert Method

```csharp
public override bool CanConvert(Type objectType)
{
    return (objectType == typeof(List<T>));
}
```

This method returns a boolean value depending on whether or not this `JsonConverter` can convert an object of the specified type. In this case, it checks if the object type equals to a generic List of type `T`.

### ReadJson Method

```csharp
public override object ReadJson(
    JsonReader reader,
    Type objectType,
    object existingValue,
    JsonSerializer serializer)
{
    var token = JToken.Load(reader);
    return token.Type == JTokenType.Array ? token.ToObject<List<T>>() : [token.ToObject<T>()];
}
```
The `ReadJson` method reads the JSON representation of the object. It first loads the `JsonReader` to a `JToken`, then depending on the `JToken` type, it converts and returns the JSON as List<T> object or as a single object of type T.

**Parameter:**
- `JsonReader reader`: A JsonReader instance that reads the JSON content.
- `Type objectType`: The type of the object.
- `object existingValue`: The existing value of an object being read.
- `JsonSerializer serializer`: The calling serializer.

### CanWrite Property

```csharp
public override bool CanWrite => false;
```

This property gets a value indicating whether this JsonConverter can write JSON. It is overridden to always return false in this case. This implies that this converter cannot write or serialize back to JSON.

### WriteJson Method

```csharp
public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
{
    throw new NotImplementedException();
}
```

The `WriteJson` method writes the JSON representation of the object. In this case, it just throws a `NotImplementedException` because JSON write operation is not implemented in this class. This is typically the case when the converter is only used for deserialization. 

**Parameter:**
- `JsonWriter writer`: A JsonWriter instance that writes to JSON.
- `object value`: The value to convert.
- `JsonSerializer serializer`: The calling serializer.