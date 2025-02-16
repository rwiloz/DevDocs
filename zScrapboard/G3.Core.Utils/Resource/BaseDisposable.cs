using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Resource
{

    public class BaseDisposable : IDisposable
    {
        private bool disposed = false;

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void OnFreeManage() { }
        protected virtual void OnFreeUnManage() { }
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

        // Use C# destructor syntax for finalization code.
        ~BaseDisposable()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
    }


}
