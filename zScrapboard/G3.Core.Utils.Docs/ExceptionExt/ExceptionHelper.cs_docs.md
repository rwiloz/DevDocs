---
title: "ExceptionHelper Utility"
description: "Documentation for ExceptionHelper class in G3.Core.Utils.ExceptionExt namespace."
date: 2023-10-05
draft: false
---

# ExceptionHelper Utility

The `ExceptionHelper` class provides utility methods to extend the functionalities of exception objects in .NET. It includes methods to generate detailed messages and complete stack traces, which help in debugging and logging.

## Namespace

`G3.Core.Utils.ExceptionExt`

## Methods

### ToMessage

This method generates a detailed message from an `Exception` object, optionally including the stack trace, the type name, and inner exceptions.

#### Syntax

```csharp
public static string ToMessage(this Exception ex, bool includeStackTrace = false, bool includeExceptionTypeName = true, bool includeInnerExceptions = true)
```

#### Parameters

- `ex`: The `Exception` object for which the message is generated.
- `includeStackTrace`: (Optional) A `Boolean` value indicating whether the stack trace should be included. Default is `false`.
- `includeExceptionTypeName`: (Optional) A `Boolean` value indicating whether the exception type name should be included. Default is `true`.
- `includeInnerExceptions`: (Optional) A `Boolean` value indicating whether inner exceptions should be included. Default is `true`.

#### Returns

A `String` containing the detailed message of the exception.

#### Example

```csharp
try
{
    // Code that may throw exceptions
}
catch (Exception ex)
{
    string message = ex.ToMessage(includeStackTrace: true);
    Console.WriteLine(message);
}
```

### ToStackTrace

This method generates a complete stack trace for an `Exception` object, including the details of nested inner exceptions.

#### Syntax

```csharp
public static string ToStackTrace(this Exception ex)
```

#### Parameters

- `ex`: The `Exception` object for which the stack trace is generated.

#### Returns

A `String` containing the complete stack trace of the exception.

#### Example

```csharp
try
{
    // Code that may throw exceptions
}
catch (Exception ex)
{
    string stackTrace = ex.ToStackTrace();
    Console.WriteLine(stackTrace);
}
```

## Usage

To use these methods, add a reference to the `G3.Core.Utils.ExceptionExt` namespace and call the methods as extensions on an `Exception` object to retrieve detailed messages and stack traces.

These utilities are particularly useful in logging scenarios where comprehensive error details are required for diagnosis and troubleshooting.