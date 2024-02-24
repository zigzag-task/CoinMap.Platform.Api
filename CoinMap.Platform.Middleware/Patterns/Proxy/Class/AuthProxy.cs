using CoinMap.Platform.Middleware.Dto;
using CoinMap.Platform.Middleware.Gateways;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;

namespace CoinMap.Platform.Middleware.Patterns.Proxy.Class
{
    public class AuthProxy : IAuthProxy
    {
        #region Properties
        private readonly AuthApiGateway _authApiGateway;
        #endregion

        public AuthProxy(IServiceProvider provider)
        {
            this._authApiGateway = new AuthApiGateway(provider);
        }

        public async Task<AuthDto> Login(UserDto user)
        {
            return await this._authApiGateway.Login(user);
        }

        public async Task<AuthDto> Registration(UserDto user)
        {
            return await this._authApiGateway.Registration(user);
        }
    }
}
