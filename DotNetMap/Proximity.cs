using System;
using System.Collections.Generic;

namespace DotNetMap
{
    public class Proximity : GeographicalPoint
    {
        private double radiusInMeters;

        public Proximity(double centerLatitude, double centerLongitude, double radiusInMeters)
            : base(centerLatitude, centerLongitude)
        {
            this.RadiusInMeters = radiusInMeters;
        }

        public double RadiusInMeters
        {
            get
            {
                return this.radiusInMeters;
            }

            private set
            {
                this.radiusInMeters = value;
            }
        }

        public List<GeographicalPoint> GetCirclePoints()
        {
            var myCirclePoints = new List<GeographicalPoint>();

            double lat = Converters.DegToRad(this.Latitude); // rad
            double lon = Converters.DegToRad(this.Longitude); // rad
            double r = 6371; // earth's mean radius in km
            double d = (this.RadiusInMeters / 1000d) / r; // d = angular distance covered on earth's surface

            for (int x = 0; x <= 360; x++)
            {
                double pt_lat;
                double pt_long;

                double brng = Converters.DegToRad(x); // rad
                pt_lat = Math.Asin(Math.Sin(lat) * Math.Cos(d) + Math.Cos(lat) * Math.Sin(d) * Math.Cos(brng));

                pt_long = Converters.RadToDeg(lon + Math.Atan2(Math.Sin(brng) * Math.Sin(d) * Math.Cos(lat), Math.Cos(d) - Math.Sin(lat) * Math.Sin(pt_lat))); // deg
                pt_lat = Converters.RadToDeg(pt_lat);

                myCirclePoints.Add(new GeographicalPoint(pt_lat, pt_long));
            }

            return myCirclePoints;
        }
    }
}