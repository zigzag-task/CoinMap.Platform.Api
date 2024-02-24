using Newtonsoft.Json;

namespace CoinMap.Platform.Api.Boundary.Response
{
    public class VenueResponse
    {

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("geolocation")]
        public string Geolocation { get; set; } = null!;
    }
}