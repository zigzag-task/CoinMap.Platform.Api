using CoinMap.Platform.Api.Boundary.Request.Abstract;
using CoinMap.Platform.Api.Boundary.Request.Class;
using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Api.Extensions.Factories;
using CoinMap.Platform.Api.UseCase.Abstract;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;

namespace CoinMap.Platform.Api.UseCase.Class
{
    public class GetAllByCategory : BaseUseCase<IEnumerable<VenueResponse>>
    {
        private readonly IVenueProxy _venueProxy;

        public GetAllByCategory(IVenueProxy venueProxy)
        {
            this._venueProxy = venueProxy;
        }

        public override async Task<IEnumerable<VenueResponse>> ExecuteAsync(RequestViewModel? request)
        {
            string category = (request as VenueQuery)!.Category;

            var venues = await this._venueProxy.GetAllByCategoryAsync(category);

            return venues.ToResponse();
        }
    }
}
