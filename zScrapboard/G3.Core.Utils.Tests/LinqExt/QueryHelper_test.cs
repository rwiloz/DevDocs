Here's a basic set of unit tests using xUnit and Moq frameworks. These tests create mock data and validate that the correct sorting, filtering and ordering methods get called. Note that this is just a small set of tests and doesn't completely cover all possible test cases, but it should serve as a good starting point.

```csharp
using G3.Core.Utils.LinqExt;
using Moq;
using System;
using System.Linq;
using Xunit;

public class QueryHelperTests
{
    private IQueryable<TestModel> query = null;
    private Mock<ISomeRepository> repoMock;

    public QueryHelperTests()
    {
        this.repoMock = new Mock<ISomeRepository>();
        var data = new List<TestModel>()
        {
            new TestModel { Id = 1, Prop1 = "A", Prop2 = "B" },
            new TestModel { Id = 2, Prop1 = "C", Prop2 = "D" },
            new TestModel { Id = 3, Prop1 = "E", Prop2 = "F" },
        };

        this.repoMock.Setup(r => r.GetData()).Returns(data.AsQueryable());
        this.query = data.AsQueryable();
    }

    [Fact]
    public void OrderBy_OrderByAsc_Success()
    {
        var result = query.OrderBy("Prop1", "asc");

        Assert.Equal(1, result.First().Id);
        Assert.Equal(3, result.Last().Id);
    }

    [Fact]
    public void OrderBy_OrderByDesc_Success()
    {
        var result = query.OrderByDescending("Prop1", "desc");

        Assert.Equal(3, result.First().Id);
        Assert.Equal(1, result.Last().Id);
    }

    [Fact]
    public void Where_StringPropertyEqual_Success()
    {
        var result = query.Where("Prop1", "E");

        Assert.Single(result);
        Assert.Equal(3, result.First().Id);
    }

    [Fact]
    public void Where_BinarySearchPropertyLessThanOrEqual_Success()
    {
        var result = query.Where("Id", "2", QueryHelperBinarySearch.LessThanOrEqual);

        Assert.Equal(2, result.Count());
    }

    // Add more tests...
}

public class TestModel
{
    public int Id { get; set; }
    public string Prop1 { get; set; }
    public string Prop2 { get; set; }
}

public interface ISomeRepository
{
    IQueryable<TestModel> GetData();
}
```
Please continue to add more suitable test cases based on your testing approach and the complexity of your Query Helper.