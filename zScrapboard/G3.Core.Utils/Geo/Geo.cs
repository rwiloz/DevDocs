using System;

namespace G3.Core.Utils.Geo
{
    public class GeoPoint
    {
        public GeoPoint()
        {

        }

        public GeoPoint(double? lat, double? lng)
        {
            Lat = lat ?? 0;
            Lng = lng ?? 0;
        }

        public GeoPoint(decimal? lat, decimal? lng)
        {
            Lat = (double) (lat ?? 0);
            Lng = (double) (lng ?? 0);
        }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public static class GeoExt
    {
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
