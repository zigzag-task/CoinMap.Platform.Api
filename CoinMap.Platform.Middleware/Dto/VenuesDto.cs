using Newtonsoft.Json;

namespace CoinMap.Platform.Middleware.Dto
{
    public class VenuesDto
    {
        [JsonProperty("venues")]
        public IEnumerable<VenueDto> Data { get; set; } = null!;
    }
}
