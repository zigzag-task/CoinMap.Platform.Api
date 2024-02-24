using Newtonsoft.Json;

namespace CoinMap.Platform.Middleware.Dto
{
    public class VenueDto
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("geolocation_degrees")]
        public string Geolocation { get; set; } = null!;
    }
}
