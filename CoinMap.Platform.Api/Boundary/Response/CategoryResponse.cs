using Newtonsoft.Json;

namespace CoinMap.Platform.Api.Boundary.Response
{
    public class CategoryResponse
    {
        [JsonProperty("category")]
        public string Category { get; set; } = null!;
    }
}
