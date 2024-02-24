using CoinMap.Platform.Infrastructure.Patterns.Repository.Interface;
using CoinMap.Platform.Middleware.Dto;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;
using CoinMap.Platform.Middleware.Extensions.Factories;
using Microsoft.Extensions.DependencyInjection;
using CoinMap.Platform.Infrastructure.Provider.Interface;

namespace CoinMap.Platform.Middleware.Gateways
{
    internal class CategoryApiGateway : ICategoryProxy
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IApiProvider<CategoriesDto> _apiProvider;

        public CategoryApiGateway(IServiceProvider provider)
        {
            IServiceScope scope = provider.CreateScope();

            this._categoryRepository = scope.ServiceProvider.GetRequiredService<ICategoryRepository>();

            this._apiProvider = scope.ServiceProvider.GetRequiredService<IApiProvider<CategoriesDto>>();

        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
            var count = await this._categoryRepository.CountAsync(_ => true);

            if (count == 0) 
            {
                var collection = await this._apiProvider.ListAsync();

                await this._categoryRepository.AddRangeAsync(collection.Data.DistinctBy(item => item.Category).FromResult());
            }

            var categories = await this._categoryRepository.ListAsync();

            return categories.AsEnumerable().ToResult();
        }
    }
}