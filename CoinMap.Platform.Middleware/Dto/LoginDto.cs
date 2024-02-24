using CoinMap.Platform.Middleware.Enums;

namespace CoinMap.Platform.Middleware.Dto
{
    public class LoginDto
    {
        public AuthStatusEnum Status { get; set; }

        public string Message { get; set; } = null!;

        public string Token { get; set; } = null!;
    }
}
