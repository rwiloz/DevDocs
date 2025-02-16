Here are some example test cases for your FormatterUtil class in a hypothetical FormatterUtilTest class.

```
using NUnit.Framework;
using System;
using G3.Core.Utils.DataType;

[TestFixture]
public class FormatterUtilTest
{
    [Test]
    public void Test_FormatDateDMY_()
    {
        DateTime testDate = new DateTime(2020, 12, 31);
        string result = testDate.FormatDateDMY_();
        Assert.AreEqual("31_12_2020", result);
    }
    
    [Test]
    public void Test_FormatDateDMY_AU()
    {
        DateTime testDate = new DateTime(2020, 12, 31);
        string result = testDate.FormatDateDMY(CultureCodeContants.enAU);
        Assert.AreEqual("31/12/2020", result);
    }

    [Test]
    public void Test_FormatDateDMY_US()
    {
        DateTime testDate = new DateTime(2021, 1, 10);
        string result = testDate.FormatDateDMY(CultureCodeContants.enUS);
        Assert.AreEqual("01/10/2021", result);
    }

    [Test]
    public void Test_FormatISODate()
    {
        DateTime testDate = new DateTime(2020, 12, 31, 13, 14, 15, 987);
        string result = testDate.FormatISODate();
        Assert.AreEqual("2020-12-31T13:14:15.987", result);
    }

    [Test]
    public void Test_FormatDateYMD()
    {
        DateTime testDate = new DateTime(2020, 12, 31);
        string result = testDate.FormatDateYMD();
        Assert.AreEqual("2020-12-31", result);
    }

    [Test]
    public void Test_FormatDateYMDNoZeroFill()
    {
        DateTime testDate = new DateTime(2020, 9, 1);
        string result = testDate.FormatDateYMDNoZeroFill();
        Assert.AreEqual("2020-9-1", result);
    }

    [Test]
    public void Test_FormatTimeHM24()
    {
        DateTime testDate = new DateTime(1, 1, 1, 13, 14, 0);
        string result = testDate.FormatTimeHM24();
        Assert.AreEqual("13:14", result);
    }
 
    [Test]
    public void Test_FormatDateTime()
    {
        DateTime testDate = new DateTime(2020, 12, 31, 13, 14, 15);
        string result = testDate.FormatDateTime();
        Assert.AreEqual("31/12/2020 01:14 PM", result);
    }
}
```
These examples test the basic functionality of each method, assuming the CultureCodeContants class provides "enAU" and "enUS" constants and a IsUS method for identifying US culture code. Make necessary modifications based on your real implementation and cover more test cases if needed.