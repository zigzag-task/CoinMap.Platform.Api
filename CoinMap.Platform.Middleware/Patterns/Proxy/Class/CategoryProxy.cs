using CoinMap.Platform.Middleware.Dto;
using CoinMap.Platform.Middleware.Gateways;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;

namespace CoinMap.Platform.Middleware.Patterns.Proxy.Class
{
    public class CategoryProxy : ICategoryProxy
    {
        #region Properties
        private readonly CategoryApiGateway _categoryApiGateway;
        #endregion

        public CategoryProxy(IServiceProvider provider)
        {
            this._categoryApiGateway = new CategoryApiGateway(provider);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
            return await this._categoryApiGateway.GetAllCategoryAsync();
        }
    }
}
