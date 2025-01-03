---
title: "Exception"
description: ""
summary: ""
date: 2023-09-07T16:12:37+02:00
lastmod: 2023-09-07T16:12:37+02:00
draft: false
weight: 900
toc: true
sidebar:
  collapsed: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

# ExceptionHelper Class

This static class, "ExceptionHelper", is a part of the "G3.Core.Utils.ExceptionExt" namespace. The class provides extension methods for the Exception object to generate detailed error messages and stack traces.

## Methods

### ToMessage Method

This method extends the Exception object and generates a detailed string message based on the Exception object passed to it.

```csharp
public static string ToMessage(this Exception ex, bool includeStackTrace = false, bool includeExceptionTypeName = true, bool includeInnerExceptions = true)
```

The method takes three parameters:

- `ex`: The Exception object
- `includeStackTrace`: Determines whether the stack trace should be included in the resulting string. Default value is false.
- `includeExceptionTypeName`: Determines whether the name of the Exception class should be included in the resulting string. Default value is true.
- `includeInnerExceptions`: Determines whether if any inner exceptions should be included in the resulting string. Default value is true.

The method iteratively appends exception details to a StringBuilder `message` and returns it as a string.

### ToStackTrace Method

This method extends the Exception object to generate a complete stack trace string based on the Exception object passed to it.

```csharp
public static string ToStackTrace(this Exception ex)
```

The method accepts one parameter:

- `ex`: The Exception object

The method iteratively generates and appends stack trace details of the exception and any inner exceptions to a StringBuilder `stackTrace` and returns it as a string.