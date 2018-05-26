using System;
using System.Linq;
using Geocoding;
using Geocoding.Google;
using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class LocationJson
    {
        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("loc_accuracy")]
        public double Accuracy { get; set; }

        [JsonProperty("loc_coordinates")]
        public Coordinates LocationCoordinates { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        public class Coordinates
        {
            [JsonProperty("lat")]
            public double Latitude { get; set; }
            [JsonProperty("lng")]
            public double Longitude { get; set; }
        }

        public static LocationJson GetFromString(string address, string apiKey)
        {
            try
            {
                IGeocoder geocoder = new GoogleGeocoder() { ApiKey = apiKey };
                var formatted = (GoogleAddress)geocoder.Geocode(address).FirstOrDefault();

                if (formatted == null)
                {
                    return null;
                }

                var ret = new LocationJson
                {
                    Accuracy = 0.0,
                    City = formatted.Components.FirstOrDefault(x => x.Types.Contains(GoogleAddressType.Locality)).LongName,
                    Country = formatted.Components.FirstOrDefault(x => x.Types.Contains(GoogleAddressType.Country))
                        .ShortName,
                    LocationCoordinates = new Coordinates()
                    {
                        Latitude = formatted.Coordinates.Latitude,
                        Longitude = formatted.Coordinates.Longitude
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
