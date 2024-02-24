using CoinMap.Platform.Infrastructure.Entities;
using System.Linq.Expressions;

namespace CoinMap.Platform.Infrastructure.Patterns.Repository.Interface
{
    public interface IVenueRepository
    {
        Task AddRangeAsync(IEnumerable<VenueEntity> documents);

        Task<IEnumerable<VenueEntity>> FilterByAsync(Expression<Func<VenueEntity, bool>> filterExpression);

        Task<long> CountAsync(Expression<Func<VenueEntity, bool>> filterExpression);
    }
}
