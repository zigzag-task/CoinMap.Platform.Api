using CoinMap.Platform.Api.Boundary.Request.Abstract;
using CoinMap.Platform.Api.Boundary.Request.Class;
using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Api.Extensions.Factories;
using CoinMap.Platform.Api.UseCase.Abstract;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;

namespace CoinMap.Platform.Api.UseCase.Class
{
    public class Login : BaseUseCase<LoginResponse>
    {
        private readonly IAuthProxy _authProxy;

        public Login(IAuthProxy authProxy)
        {
            this._authProxy = authProxy;
        }

        public override async Task<LoginResponse> ExecuteAsync(RequestViewModel? request)
        {
            var userDto = (request as LoginQuery)!.ToRequest();

            var response = await this._authProxy.Login(userDto);

            return response.ToResponse().Login;
        }
    }
}
