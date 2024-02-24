using Newtonsoft.Json;

namespace CoinMap.Platform.Middleware.Dto
{
    public class CategoriesDto
    {
        [JsonProperty("venues")]
        public IEnumerable<CategoryDto> Data { get; set; } = null!;
    }
}
