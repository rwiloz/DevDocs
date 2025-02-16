---
title: "HttpHelpers Class in G3.Core.Utils.Http"
date: 2023-12-01
draft: false
---

# HttpHelpers Class

The `HttpHelpers` class is a static utility class within the `G3.Core.Utils.Http` namespace. It provides methods to assist with HTTP content type handling, focusing on ensuring UTF-8 encoding is included where necessary.

## Namespace

`G3.Core.Utils.Http`

## Class Definition

### Static Methods

#### `CheckAddUtf8`

```csharp
public static string CheckAddUtf8(this string contentType)
```

The `CheckAddUtf8` method is an extension method for the `string` class. It checks if the given `contentType` is among a set of predefined text-based types and appends `charset=utf-8` to the `contentType` if necessary.

##### Parameters

- `contentType` (`string`): The content type to be checked.

##### Returns

- `string`: The original content type with `; charset=utf-8` appended if it's identified as a text-based type from the specified list. Returns the original content type string if no match is found.

##### Example

```csharp
string contentType = "application/json";
string result = contentType.CheckAddUtf8(); 
// result: "application/json; charset=utf-8"
```

## Usage

Leverage the `CheckAddUtf8` extension method when you need to ensure that certain content types are UTF-8 encoded. This is useful for preparing HTTP content types before sending responses from a server application.

### Supported Content Types

The method specifically checks for the following content types:
- `text/html`
- `application/javascript`
- `application/json`
- `text/css`
- `application/manifest+json`
- `image/svg+xml`

These content types are commonly used in web applications that require UTF-8 character encoding for proper client-side rendering.

---

ℹ️ The `HttpHelpers` class does not maintain any state and only provides convenience methods for handling HTTP headers related to content types.
```