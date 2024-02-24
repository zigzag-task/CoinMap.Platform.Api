using CoinMap.Platform.Infrastructure.Attributes;

namespace CoinMap.Platform.Infrastructure.Entities
{
    [BsonCollection("Categories")]
    public class CategoryEntity : BaseEntity
    {
        public string Category { get; set; } = null!;
    }
}
