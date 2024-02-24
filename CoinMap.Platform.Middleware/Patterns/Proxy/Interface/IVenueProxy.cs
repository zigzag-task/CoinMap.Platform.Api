using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Middleware.Patterns.Proxy.Interface
{
    public interface IVenueProxy
    {
        Task<IEnumerable<VenueDto>> GetAllByCategoryAsync(string category);
    }
}
