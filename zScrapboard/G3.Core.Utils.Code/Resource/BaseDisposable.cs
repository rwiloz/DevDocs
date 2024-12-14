Here's your code with added XML summary comments:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Resource
{
    /// <summary>
    /// Defines the base class for objects that release managed and unmanaged resources.
    /// </summary>
    public class BaseDisposable : IDisposable
    {
        private bool disposed = false;

        /// <summary>
        /// Releases all resources used by the current instance of the BaseDisposable class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the managed resources.
        /// </summary>
        protected virtual void OnFreeManage() { }
        
        /// <summary>
        /// Releases the unmanaged resources.
        /// </summary>
        protected virtual void OnFreeUnManage() { }
        
        /// <summary>
        /// Releases the unmanaged resources and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    OnFreeManage();
                }
                OnFreeUnManage();
                disposed = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the BaseDisposable class.
        /// </summary>
        ~BaseDisposable()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
    }
}
```

These XML comments can be used to automatically generate documentation, provide tooltips when using your code as a library, and aid in understanding when reading the source code. This can be really helpful for you and other developers who might use or maintain your code.