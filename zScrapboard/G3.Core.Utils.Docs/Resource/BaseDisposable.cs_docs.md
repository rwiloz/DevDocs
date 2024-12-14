# Class: BaseDisposable

This class is located within the namespace `G3.Core.Utils.Resource`. It is a BaseDisposable class that implements the `IDisposable` interface from System namespace providing a basic disposal mechanism for managed and unmanaged resources.

## Fields:
- **disposed (private bool)**: A boolean flag indicating whether the object has been disposed of or not. It's initialized as false.

## Methods:
- **Dispose() (public void)**: It's an implementation of the `IDisposable.Dispose` method. It disposes the object and requests the system not to call the finalizer for this object, which helps improving performance.

- **OnFreeManage() (protected virtual void):** An empty virtual method which can be overridden by derived classes to free managed resources.

- **OnFreeUnManage() (protected virtual void):** An empty virtual method which can be overridden by derived classes to free unmanaged resources. 

- **Dispose(bool disposing) (protected virtual void):** A method that actual performs the disposal. If the object has not been disposed before, it checks the disposing parameter. If it's true, then it calls the `OnFreeManage` method to free managed resources. Regardless of the value of disposing, it calls the `OnFreeUnManage` method to free unmanaged resources. Then it marks the object as disposed.

- **~BaseDisposable() (destructor):** The destructor for the object. It's called by the system when the garbage collection happens. The purpose of this method is to free the unmanaged resources of the object. It calls `Dispose(false)` to indicate that it's being called from the finalizer.

This class is meant to be used as a base class for any class that holds resources requiring explicit release, providing a standard mechanism to clean up those resources. The derived classes just need to override `OnFreeManage` and/or `OnFreeUnManage` methods to release the specific resources.