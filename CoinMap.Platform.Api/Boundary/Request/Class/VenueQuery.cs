using CoinMap.Platform.Api.Boundary.Request.Abstract;

namespace CoinMap.Platform.Api.Boundary.Request.Class
{
    public class VenueQuery : RequestViewModel
    {
        public string Category { get; set; } = null!;
    }
}
