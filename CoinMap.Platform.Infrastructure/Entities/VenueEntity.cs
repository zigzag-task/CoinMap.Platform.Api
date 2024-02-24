using CoinMap.Platform.Infrastructure.Attributes;
using System.Runtime.Serialization;

namespace CoinMap.Platform.Infrastructure.Entities
{
    [BsonCollection("Venues")]
    public class VenueEntity : BaseEntity
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Category { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Geolocation { get; set; } = null!;
    }
}
