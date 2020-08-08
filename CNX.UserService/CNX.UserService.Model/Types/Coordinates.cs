using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.UserService.Model.Types
{
    public struct Coordinates
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public bool IsValid { get; internal set; }

        private bool validLat;
        private bool validLon;

        public Coordinates(double latitude, double longitude)
        {
            Latitude = setLatitude(latitude, out validLat);
            Longitude = setLongitude(longitude, out validLon);
            IsValid = validLat && validLon;
        }

        private static double setLongitude(double longitude, out bool isValid)
        {
            if (longitude < -180 || longitude > 180)
            {
                isValid = false;
                return 0;
            }
            isValid = true;
            return longitude;
        }

        private static double setLatitude(double latitude, out bool isValid)
        {
            if (latitude < -90 || latitude > 90)
            {
                isValid = false;
                return 0;
            }
            isValid = true;
            return latitude;
        }
    }
}
