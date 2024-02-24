using CoinMap.Platform.Api.Boundary.Request.Abstract;
using CoinMap.Platform.Api.Boundary.Request.Class;
using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Api.Extensions.Factories;
using CoinMap.Platform.Api.UseCase.Abstract;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;

namespace CoinMap.Platform.Api.UseCase.Class
{
    public class Registration : BaseUseCase<RegisterResponse>
    {
        private readonly IAuthProxy _authProxy;

        public Registration(IAuthProxy authProxy)
        {
            this._authProxy = authProxy;
        }

        public override async Task<RegisterResponse> ExecuteAsync(RequestViewModel? request)
        {
            var userDto = (request as RegisterQuery)!.ToRequest();

            var response = await this._authProxy.Registration(userDto);

            return response.ToResponse().Register;
        }
    }
}
