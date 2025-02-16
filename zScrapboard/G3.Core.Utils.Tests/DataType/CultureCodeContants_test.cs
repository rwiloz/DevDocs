Here are the test cases for your provided code snippet:

```csharp
using NUnit.Framework;
using G3.Core.Utils.DataType;
using System;

namespace G3.UnitTests
{
    [TestFixture]
    public class CultureCodeContantsTests
    {
        [Test]
        public void IsUS_WhenCalledWithUSCulture_ReturnsTrue()
        {
            Assert.IsTrue(CultureCodeContants.IsUS(CultureCodeContants.enUS));
            Assert.IsTrue(CultureCodeContants.IsUS(CultureCodeContants.enSP));
        }

        [Test]
        public void IsUS_WhenCalledWithNonUSCulture_ReturnsFalse()
        {
            Assert.IsFalse(CultureCodeContants.IsUS(CultureCodeContants.enAU));
        }

        [Test]
        public void GetDateFormat_WhenCalledWithUSCulture_ReturnsUSFormat()
        {
            Assert.AreEqual("MM/dd/yyyy", CultureCodeContants.GetDateFormat(CultureCodeContants.enUS));
        }

        [Test]
        public void GetDateFormat_WhenCalledWithNonUSCulture_ReturnsNonUSFormat()
        {
            Assert.AreEqual("dd/MM/yyyy", CultureCodeContants.GetDateFormat(CultureCodeContants.enAU));
        }

        [Test]
        public void GetDateTime_WhenValidUSDate_ReturnsDate()
        {
            DateTime? date = CultureCodeContants.GetDateTime(CultureCodeContants.enUS, "12/31/2022");
            Assert.AreEqual(new DateTime(2022, 12, 31), date.Value);
        }

        [Test]
        public void GetDateTime_WhenValidNonUSDate_ReturnsDate()
        {
            DateTime? date = CultureCodeContants.GetDateTime(CultureCodeContants.enAU, "31/12/2022");
            Assert.AreEqual(new DateTime(2022, 12, 31), date.Value);
        }

        [Test]
        public void GetDateTime_WhenInvalidDate_ReturnsNull()
        {
            DateTime? date = CultureCodeContants.GetDateTime(CultureCodeContants.enAU, "31/13/2022");
            Assert.IsNull(date);
        }
    }
}
```

This series of tests examines the behavior of the methods under different inputs, such as different culture codes and date formats. It provides a good base to further extend these tests if needed. Please make sure you have the NUnit framework installed in your project for these tests to run.