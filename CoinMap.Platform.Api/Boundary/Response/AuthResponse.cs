namespace CoinMap.Platform.Api.Boundary.Response
{
    public class AuthResponse
    {
        public LoginResponse Login { get; set; } = null!;
        public RegisterResponse Register { get; set; } = null!;
    }
}
