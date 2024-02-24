using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Middleware.Patterns.Proxy.Interface
{
    public interface IAuthProxy
    {
        Task<AuthDto> Login(UserDto user);
        Task<AuthDto> Registration(UserDto user);
    }
}
