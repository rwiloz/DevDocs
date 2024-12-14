# Class: JsonCopy

This class is part of implementing Json library in C#. It's present within the `G3.Core.Utils.JsonExt` namespace. It's a static class and cannot be instantiated.

The `JsonCopy` class includes a single method, `Copy<TDest>` which is a generic method. 

## Method: Copy<TDest>(object src)

This method is designed to clone or copy an object to another object of a different type (`TDest`). 

Parameters:
- `object src`: This is the source object that is to be cloned or copied.

Return Type:
- `TDest`: This method returns an object of type `TDest` which is a clone/copy of the source object.

The method serializes the source object into a JSON string using the `SerializeObject` method from `JsonConvert` class and using the settings defined in `JsonUtils.JsonSettings` object. 

Then, it deserializes that JSON string back into an object of type `TDest` using the `DeserializeObject` method from `JsonConvert` class and using the same settings. 

This process ensures that the user gets a copy of the source object, transformed into the type `TDest`. 

This method is effective for copying complex objects and where conversion constructors are not available or practical. It's important to ensure it's used where type `TDest` can map to the properties of the source object to avoid any run-time errors.