The test cases for the above C# program can be:

```csharp
using G3.Core.Utils.DataType;
using Xunit;
using System;

public class DateUtilTests
{
    [Fact]
    public void TestAge()
    {
        DateTime dob = new DateTime(1990, 10, 20);
        DateTime current = new DateTime(2020, 10, 20);
        int age = DateUtil.Age(dob, current);
        Assert.Equal(30, age);
    }
    
    [Fact]
    public void TestParseNullableDate()
    {
        DateTime? date = DateUtil.ParseNullableDate("11/23/2020");
        Assert.NotNull(date);
        Assert.Equal(2020, date.Value.Year);
    }

    [Fact]
    public void TestValidDateRange()
    {
        DateTime? dateInRange = new DateTime(2020, 12, 31);
        Assert.True(DateUtil.ValidDateRange(dateInRange));

        DateTime? dateOutOfRange = new DateTime(9999, 12, 31);
        Assert.False(DateUtil.ValidDateRange(dateOutOfRange));
    }

    [Fact]
    public void TestIsInDateRange()
    {
        DateTime? date = new DateTime(2020, 12, 31);
        DateTime? start = new DateTime(2020, 12, 1);
        DateTime? end = new DateTime(2030, 12, 31);
        Assert.True(date.IsInDateRange(start, end));

        DateTime? date2 = new DateTime(2000, 12, 31);
        Assert.False(date2.IsInDateRange(start, end));

        DateTime? date3 = null;
        Assert.False(date3.IsInDateRange(start, end));
    }
    
    [Fact]
    public void TestCalculateAverageMonthSpan()
    {
        DateTime start = new DateTime(2020, 1, 1);
        DateTime end = new DateTime(2020, 12, 31);
        Assert.Equal(12, start.CalculateAverageMonthSpan(end));
    }

    [Fact]
    public void TestCheckHoliday()
    {
        DateTime? date = new DateTime(2012, 1, 1);
        var holiday = DateUtil.CheckHoliday(date, "VIC");
        Assert.NotNull(holiday);
        Assert.Equal("NewYear", holiday.Type);

        DateTime? date2 = new DateTime(2021, 7, 4);
        var holiday2 = DateUtil.CheckHoliday(date2, "VIC");
        Assert.Null(holiday2);
    }
}
```

These cases will help you to make sure your functions are running correctly. Remember to import the correct namespace and run with Xunit Test Runner.