Here's a simple unit test class for exercising your extension methods:

```csharp
using System;
using G3.Core.Utils.ExceptionExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace G3.Tests
{
    [TestClass]
    public class ExceptionHelperTests
    {
        [TestMethod]
        public void ToMessage_IncludesStackTrace()
        {
            try
            {
                throw new InvalidOperationException("This is a test exception");
            }
            catch (Exception ex)
            {
                var message = ex.ToMessage(true);

                // Assert that our message includes the exception type and stack trace
                Assert.IsTrue(message.Contains("InvalidOperationException:"));
                Assert.IsTrue(message.Contains("at G3.Tests.ExceptionHelperTests"));
            }
        }

        [TestMethod]
        public void ToMessage_IncludesInnerException()
        {
            try
            {
                try
                {
                    throw new InvalidOperationException("This is an inner exception");
                }
                catch (Exception innerEx)
                {
                    throw new ArgumentException("This is a test exception", innerEx);
                }
            }
            catch (Exception ex)
            {
                var message = ex.ToMessage(false, true, true);

                // Assert that our message includes the inner exception
                Assert.IsTrue(message.Contains("InvalidOperationException:")); // inner
                Assert.IsTrue(message.Contains("ArgumentException:")); // outer
            }
        }

        [TestMethod]
        public void ToStackTrace_ShouldExtractCorrectly()
        {
            try
            {
                throw new InvalidOperationException("This is a test exception");
            }
            catch (Exception ex)
            {
                var stackTrace = ex.ToStackTrace();

                // Assert that our stack trace includes the exception type and method details
                Assert.IsTrue(stackTrace.Contains("InvalidOperationException"));
                Assert.IsTrue(stackTrace.Contains("at G3.Tests.ExceptionHelperTests"));
            }
        }
    }
}
```

This class tests the ToMessage() method and ensures that it correctly includes the stack trace, and the inner exception message. This class also tests the ToStackTrace() method to ensure that it correctly generates the full stack trace.