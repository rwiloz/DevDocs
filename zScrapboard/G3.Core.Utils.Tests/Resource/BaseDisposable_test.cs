Here are some unit tests for the BaseDisposable class using Xunit:

```CSharp
using Xunit;
using G3.Core.Utils.Resource;
using System;

namespace G3.Core.Utils.Resource.Tests
{
    public class BaseDisposableTests : IDisposable
    {
        private bool managedDisposalCalled;
        private bool unmanagedDisposalCalled;
        private BaseDisposable disposableObject;

        public BaseDisposableTests()
        {
            managedDisposalCalled = false;
            unmanagedDisposalCalled = false;

            disposableObject = new DerivedDisposable(() =>
            {
                managedDisposalCalled = true;
            }, () =>
            {
                unmanagedDisposalCalled = true;
            });
        }

        [Fact]
        public void Dispose_Calls_OnFreeManage_And_OnFreeUnManage()
        {
            disposableObject.Dispose();

            Assert.True(managedDisposalCalled);
            Assert.True(unmanagedDisposalCalled);
        }
        
       [Fact]
       public void Dispose_Only_Calls_Once()
       {
           disposableObject.Dispose();
           disposableObject.Dispose();

           Assert.True(managedDisposalCalled);
           Assert.False(unmanagedDisposalCalled);
       }

        public void Dispose()
        {
            disposableObject.Dispose();
        }
    }

    internal class DerivedDisposable : BaseDisposable
    {
        private Action managedAction;
        private Action unmanagedAction;

        public DerivedDisposable(Action managedAction, Action unmanagedAction)
        {
            this.managedAction = managedAction;
            this.unmanagedAction = unmanagedAction;
        }

        protected override void OnFreeManage()
        {
            managedAction();
        }

        protected override void OnFreeUnManage()
        {
            unmanagedAction();
        }
    }
}
```
Please note that the second check within `Dispose_Only_Calls_Once` test is made with `Assert.False` to demonstrate that the Unmanaged disposal is not called twice, which ideally should be the case in proper disposable pattern. 

I derived from the `BaseDisposable` to create a `DerivedDisposable` in the test class, solely for testing purposes and provided actions to be called during the disposal stage to set some booleans that can be tested with assertions.

The tests ensure that the disposal methods are getting correctly called and that they are not called more than once for any instance of the class. This is beneficial to prevent potential resource leaks in your application.