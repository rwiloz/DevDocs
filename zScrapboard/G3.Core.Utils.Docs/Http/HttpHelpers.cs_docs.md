# HttpHelpers Class

This class resides in the `G3.Core.Utils.Http` namespace and contains utilities for handling HTTP related tasks.

## Method: CheckAddUtf8

```CSharp
public static string CheckAddUtf8(this string contentType)
```

This is an extension method applicable to a string object. It checks if the content type of an HTTP request/response needs to be appended with `charset=utf-8` or not.

Parameters:

- `contentType`: This parameter accepts a string value which represents content type of an HTTP request/response.

Returns: 

- A string that is either unmodified (if the input content type is not part of the predefined list) or appended with `charset=utf-8`.

### Details

Internally, this method maintains a list of content types that need the UTF-8 charset specification, which includes:

- "text/html"
- "application/javascript"
- "application/json"
- "text/css"
- "application/manifest+json"
- "image/svg+xml"

If the `contentType` argument provided when calling this method matches any item in the list, the method appends "; charset=utf-8" to `contentType`. If not, it simply returns the `contentType` unchanged.