using CoinMapWeb;

namespace CoinMap.Platform.Api.GraphQL
{
    public class Query
    {
        public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync(string version, string api_version, string x_Version, [Service] CoinMapService service, CancellationToken cancellationToken)
        {
            return await service.CategoryAsync(version, api_version, x_Version, cancellationToken);
        }

        public async Task<IEnumerable<VenueResponse>> GetVenuesAsync(string category, string version, string api_version, string x_Version, [Service] CoinMapService service)
        {
            return await service.VenueAsync(category, version, api_version, x_Version);
        }
    }
}
