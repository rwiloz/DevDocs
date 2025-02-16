---
title: "BaseDisposable Class Documentation"
date: 2023-10-14
draft: false
description: "Detailed documentation for the BaseDisposable class in the G3.Core.Utils.Resource namespace."
---

# BaseDisposable Class

The `BaseDisposable` class is part of the `G3.Core.Utils.Resource` namespace and provides a base implementation for the `IDisposable` interface, assisting with the management of unmanaged resources. This class is designed to support both managed and unmanaged resource cleanup with proper disposal patterns.

## Namespace

```csharp
G3.Core.Utils.Resource
```

## Assembly

Include in your project by referencing the following namespace:

```csharp
using G3.Core.Utils.Resource;
```

## BaseDisposable Class

### Definition

```csharp
public class BaseDisposable : IDisposable
```

### Interfaces

- `IDisposable`: Ensures the class follows the correct pattern for releasing resources.

### Constructors and Destructors

- **Destructor**

  ```csharp
  ~BaseDisposable()
  ```

  This finalizer ensures resources are released by calling `Dispose(false)` when the object is garbage collected.

### Methods

- **Dispose() Method**

  ```csharp
  public void Dispose()
  ```

  This method is the public entry point for disposing of resources. It calls `Dispose(true)` and then suppresses finalization using `GC.SuppressFinalize(this)`.

- **Dispose(bool disposing) Method**

  ```csharp
  protected virtual void Dispose(bool disposing)
  ```

  - `disposing`: A boolean that indicates whether to dispose of managed resources (`true`) or unmanaged resources only (`false`).

  This method performs the actual resource management-specific logic; it calls specialized methods for managed and unmanaged resources and ensures disposal is only executed once.

- **OnFreeManage() Method**

  ```csharp
  protected virtual void OnFreeManage()
  ```

  A protected virtual method intended to release managed resources. Override this method to include custom cleanup logic for managed resources.

- **OnFreeUnManage() Method**

  ```csharp
  protected virtual void OnFreeUnManage()
  ```

  A protected virtual method tasked with the cleanup of unmanaged resources. Override this method to include custom unmanaged cleanup logic.

### Fields

- **disposed**

  ```csharp
  private bool disposed = false;
  ```

  A private field that tracks whether the object has already been disposed. It prevents redundant dispose operations.

## Usage

The `BaseDisposable` class provides a foundational structure for implementing custom disposables. When creating a subclass, override `OnFreeManage` and `OnFreeUnManage` to include specific resource management logic.

### Example

```csharp
public class CustomDisposable : BaseDisposable
{
    // Override the methods to implement custom disposal logic.
    protected override void OnFreeManage()
    {
        // Dispose of managed resources.
    }

    protected override void OnFreeUnManage()
    {
        // Dispose of unmanaged resources.
    }
}
```

When using the subclass, ensure that the `Dispose` method is called once the resources are no longer needed, or implement the class within a `using` statement for automatic disposal.

```csharp
using (var resource = new CustomDisposable())
{
    // Use the resource.
}
```
```