using CoinMap.Platform.Api.Boundary.Request.Abstract;
using CoinMap.Platform.Api.UseCase.Interface;

namespace CoinMap.Platform.Api.UseCase.Abstract
{
    public abstract class BaseUseCase<T> : IBaseUseCase<T>
    {
        public abstract Task<T> ExecuteAsync(RequestViewModel? request);
    }
}
