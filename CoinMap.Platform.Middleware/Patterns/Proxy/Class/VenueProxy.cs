using CoinMap.Platform.Middleware.Dto;
using CoinMap.Platform.Middleware.Gateways;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;

namespace CoinMap.Platform.Middleware.Patterns.Proxy.Class
{
    public class VenueProxy : IVenueProxy
    {
        #region Properties
        private readonly VenueApiGateway _venueApiGateway;
        #endregion

        public VenueProxy(IServiceProvider provider)
        {
            this._venueApiGateway = new VenueApiGateway(provider);
        }

        public async Task<IEnumerable<VenueDto>> GetAllByCategoryAsync(string category)
        {
            return await this._venueApiGateway.GetAllByCategoryAsync(category);
        }
    }
}
