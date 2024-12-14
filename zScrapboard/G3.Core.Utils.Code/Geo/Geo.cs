Certainly, below is the commented version of the code:

```csharp
using System;

namespace G3.Core.Utils.Geo
{
    /// <summary>
    /// Class represents a geographic point.
    /// </summary>
    public class GeoPoint
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GeoPoint()
        {

        }

        /// <summary>
        /// Overloaded constructor that accepts nullable doubles for latitude and longitude.
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lng">Longitude</param>
        public GeoPoint(double? lat, double? lng)
        {
            Lat = lat ?? 0;
            Lng = lng ?? 0;
        }

        /// <summary>
        /// Overloaded constructor that accepts nullable decimals for latitude and longitude.
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lng">Longitude</param>
        public GeoPoint(decimal? lat, decimal? lng)
        {
            Lat = (double) (lat ?? 0);
            Lng = (double) (lng ?? 0);
        }

        /// <summary>
        /// Property to get and set Latitude
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Property to get and set Longitude
        /// </summary>
        public double Lng { get; set; }
    }

    /// <summary>
    /// Class contains helper methods for GeoPoint
    /// </summary>
    public static class GeoExt
    {
        /// <summary>
        /// Method to calculate the distance between two geographic points.
        /// </summary>
        /// <param name="point1">The first geographic point</param>
        /// <param name="point2">The second geographic point</param>
        /// <returns>The distance in meters</returns>
        public static int CalculateDistance(this GeoPoint point1, GeoPoint point2)
        {
            var d1 = point1.Lat * (Math.PI / 180.0);

            var num1 = point1.Lng * (Math.PI / 180.0);
            var d2 = point2.Lat * (Math.PI / 180.0);
            var num2 = point2.Lng * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            var dist = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
            return Convert.ToInt32(dist);
        }
    }
}
```

The XML summary comments are primarily used by the IntelliSense inside the Visual Studio code editor to provide insights about types, members, and other code entities directly from the source code. This proves helpful especially in case of libraries and APIs which are published for others to use. A user can hence directly look up the usage or purpose of a code entity directly from the IntelliSense pop-up which fetches info from these XML comments.