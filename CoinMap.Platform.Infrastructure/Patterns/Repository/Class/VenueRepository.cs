using CoinMap.Platform.Infrastructure.Entities;
using CoinMap.Platform.Infrastructure.Patterns.Repository.Abstract;
using CoinMap.Platform.Infrastructure.Patterns.Repository.Interface;
using CoinMap.Platform.Infrastructure.Settings;
using System.Linq.Expressions;

namespace CoinMap.Platform.Infrastructure.Patterns.Repository.Class
{
    public class VenueRepository : AsyncRepository<VenueEntity>, IVenueRepository
    {
        public VenueRepository(IMongoDbSettings settings) : base(settings)
        {
        }

        public async Task AddRangeAsync(IEnumerable<VenueEntity> documents) => await InserManyAsync(documents);

        public async Task<IEnumerable<VenueEntity>> FilterByAsync(Expression<Func<VenueEntity, bool>> filterExpression) => await FindByAsync(filterExpression);

        public async Task<long> CountAsync(Expression<Func<VenueEntity, bool>> filterExpression) => await CountDocumentAsync(filterExpression);
    }
}
