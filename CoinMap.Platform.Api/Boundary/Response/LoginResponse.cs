using CoinMap.Platform.Middleware.Enums;
using Newtonsoft.Json;

namespace CoinMap.Platform.Api.Boundary.Response
{
    public class LoginResponse
    {
        [JsonProperty("status")]
        public AuthStatusEnum Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; } = null!;

        [JsonProperty("token")]
        public string Token { get; set; } = null!;
    }
}
