using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Geocoding;
using Geocoding.Google;
using JodelNet.Json.Responses;
using Newtonsoft.Json;

namespace JodelNet.Json.RequestModels
{
    public class SimpleLocation
    {
        public SimpleLocation()
        {
            
        }
        public SimpleLocation(LocationJson json)
        {
            City = json.City;
            Country = json.Country;

            Latitude = json.LocationCoordinates.Latitude;
            Longitude = json.LocationCoordinates.Longitude;
        }

        public string City { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public LocationJson ToJsonModel()
        {
            var ret = new LocationJson
            {
                City = City,
                Country = Country,
                Accuracy = 100,
                LocationCoordinates = new LocationJson.Coordinates
                {
                    Latitude = Latitude,
                    Longitude = Longitude
                }
            };
            return ret;
        }

        public static async Task<SimpleLocation> FromString(string location)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Accept", "application/json");
                wc.Headers.Add("Accept-Language", "de-DE,de;q=0.9,en-US;q=0.8,en;q=0.7");
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36");
                var data = await wc.DownloadStringTaskAsync("https://nominatim.openstreetmap.org/search.php?format=json&q=" + WebUtility.UrlEncode(location));

                var json = JsonConvert.DeserializeObject<List<OpenStreetMapResponse>>(data);

                var city = json.FirstOrDefault(x => x.Type == "city");

                return new SimpleLocation(){City = city.DisplayName, Country = "", Latitude = double.Parse(city.Lat, CultureInfo.InvariantCulture), Longitude = double.Parse(city.Lon, CultureInfo.InvariantCulture) };
            }
        }
    }

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
    }
}
