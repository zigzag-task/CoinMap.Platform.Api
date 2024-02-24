using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Middleware.Patterns.Proxy.Interface
{
    public interface ICategoryProxy
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();
    }
}
