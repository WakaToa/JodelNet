using System;
using System.Linq;
using Geocoding;
using Geocoding.Google;

namespace JodelNet.Json.Models
{
    public class Location
    {
        public string City { get; set; }
        public double loc_accuracy { get; set; }
        public Coordinates loc_coordinates { get; set; }
        public string country { get; set; }

        public class Coordinates
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public static Location GetFromString(string address, string apiKey)
        {
            try
            {
                IGeocoder geocoder = new GoogleGeocoder() { ApiKey = apiKey };
                var formatted = (GoogleAddress)geocoder.Geocode(address).FirstOrDefault();

                if (formatted == null)
                {
                    return null;
                }

                var ret = new Location
                {
                    loc_accuracy = 0.0,
                    City = formatted.Components.FirstOrDefault(x => x.Types.Contains(GoogleAddressType.Locality)).LongName,
                    country = formatted.Components.FirstOrDefault(x => x.Types.Contains(GoogleAddressType.Country))
                        .ShortName,
                    loc_coordinates = new Coordinates()
                    {
                        lat = formatted.Coordinates.Latitude,
                        lng = formatted.Coordinates.Longitude
                    }
                };
                return ret;

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
