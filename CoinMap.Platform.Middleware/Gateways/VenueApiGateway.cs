using CoinMap.Platform.Infrastructure.Patterns.Repository.Interface;
using CoinMap.Platform.Infrastructure.Provider.Interface;
using CoinMap.Platform.Middleware.Dto;
using CoinMap.Platform.Middleware.Extensions.Factories;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CoinMap.Platform.Middleware.Gateways
{
    internal class VenueApiGateway : IVenueProxy
    {
        private readonly IVenueRepository _venueRepository;
        private readonly IApiProvider<VenuesDto> _apiProvider;

        public VenueApiGateway(IServiceProvider provider)
        {
            IServiceScope scope = provider.CreateScope();

            this._venueRepository = scope.ServiceProvider.GetRequiredService<IVenueRepository>();

            this._apiProvider = scope.ServiceProvider.GetRequiredService<IApiProvider<VenuesDto>>();
        }

        public async Task<IEnumerable<VenueDto>> GetAllByCategoryAsync(string category) 
        {
            var count = await this._venueRepository.CountAsync(_ => true);

            if (count == 0)
            {
                var collection = await this._apiProvider.ListAsync();

                await this._venueRepository.AddRangeAsync(collection.Data.FromResult());
            }

            var venues = await this._venueRepository.FilterByAsync(item => item.Category == category);

            return venues.ToResult();
        }
    }
}
