using CoinMap.Platform.Middleware.Enums;

namespace CoinMap.Platform.Middleware.Dto
{
    public class RegisterDto
    {
        public AuthStatusEnum Status { get; set; }

        public string Message { get; set; } = null!;
    }
}
