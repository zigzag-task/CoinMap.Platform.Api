using CoinMap.Platform.Api.Boundary.Request.Abstract;

namespace CoinMap.Platform.Api.UseCase.Interface
{
    public interface IBaseUseCase<T>
    {
        public Task<T> ExecuteAsync(RequestViewModel? request);
    }
}
