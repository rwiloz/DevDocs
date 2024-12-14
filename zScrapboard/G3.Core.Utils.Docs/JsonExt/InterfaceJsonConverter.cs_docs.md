# Class: InterfaceJsonConverter

This code is part of the namespace `G3.Core.Utils.JsonExt`.

The `InterfaceJsonConverter` class inherits from the base `JsonConverter` class. This class allows WebAPI to construct Interfaces without needing to define a concrete class. It helps in managing a more dynamic and flexible JSON conversion process.

### Properties and Methods:

- `IMapper mapper` : Private readonly field that stores the mapper object that is responsible for the mapping process.
- `IEnumerable<Type> interfaces` : Private readonly enumeration that maintains the collection of interface types.

- `public InterfaceJsonConverter(IEnumerable<Type> interfaces)` : This public constructor receives an enumeration of Type interfaces, sets the local field `interfaces` and initializes the mapper for these interfaces.

- `public override bool CanConvert(Type objectType)` : This overridden method checks if the given objectType is an interface that this converter can convert.

- `public override bool CanRead`: This overridden property always returns true. It indicates that the `InterfaceJsonConverter` supports reading.

- `public override bool CanWrite`: This overridden property always returns false. It indicates that the `InterfaceJsonConverter` does not support writing. This is because the Write Json functionality works fine with interfaces, and there's no need to override it.

- `public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)`: This method is not implemented, given that the `CanWrite` property returns false.

- `public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)`: This overridden method reads a JSON and returns an object. Initially, it creates a dynamic type using AutoMapper with null values for all properties. Then, it populates these properties using Json.Net and returns the resulting object.