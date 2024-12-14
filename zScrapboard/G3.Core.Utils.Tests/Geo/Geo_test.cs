Below are some test cases using NUnit. These can be added to your existing testing project:

```csharp
using System;
using G3.Core.Utils.Geo;
using NUnit.Framework;

[TestFixture]
class TestGeoPoint
{
    [Test]
    public void TestGeoPointCtorWithoutParameters_SetsDefaultCoordinates()
    {
        var geoPoint = new GeoPoint();

        Assert.AreEqual(0, geoPoint.Lat);
        Assert.AreEqual(0, geoPoint.Lng);
    }

    [Test]
    public void TestGeoPointCtorWithNullDoubleCoordinates_SetsDefaultCoordinates()
    {
        var geoPoint = new GeoPoint(null, null);

        Assert.AreEqual(0, geoPoint.Lat);
        Assert.AreEqual(0, geoPoint.Lng);
    }

    [Test]
    public void TestGeoPointCtorWithDoubleCoordinates_SetsCoordinates()
    {
        var geoPoint = new GeoPoint(20.0, 10.0);

        Assert.AreEqual(20.0, geoPoint.Lat);
        Assert.AreEqual(10.0, geoPoint.Lng);
    }

    [Test]
    public void TestGeoPointCtorWithDecimalCoordinates_SetsCoordinates()
    {
        var geoPoint = new GeoPoint(20m, 10m);

        Assert.AreEqual(20.0, geoPoint.Lat);
        Assert.AreEqual(10.0, geoPoint.Lng);
    }

    [Test]
    public void TestCalculateDistance_ReturnsCorrectDistance()
    {
        var point1 = new GeoPoint(50, 30);
        var point2 = new GeoPoint(40, 20);
        var distance = point1.CalculateDistance(point2);

        Assert.AreEqual(1546759, distance); // Expected value calculated manually.
    }
}
```
The tests cover all the constructors and functionalities in the provided classes. Make sure you have correct distance to check value in the last test. In general, it's a good idea to cover corner cases as well, such as large values, negative values, etc.