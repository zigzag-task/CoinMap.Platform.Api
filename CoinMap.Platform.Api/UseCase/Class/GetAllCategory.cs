using CoinMap.Platform.Api.Boundary.Request.Abstract;
using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Api.Extensions.Factories;
using CoinMap.Platform.Api.UseCase.Abstract;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;

namespace CoinMap.Platform.Api.UseCase.Class
{
    public class GetAllCategory : BaseUseCase<IEnumerable<CategoryResponse>>
    {
        private readonly ICategoryProxy _categoryProxy;

        public GetAllCategory(ICategoryProxy categoryProxy)
        {
            this._categoryProxy = categoryProxy;
        }

        public override async Task<IEnumerable<CategoryResponse>> ExecuteAsync(RequestViewModel? request) 
        {
            var categories = await this._categoryProxy.GetAllCategoryAsync();

            return categories.ToResponse();
        }
    }
}
