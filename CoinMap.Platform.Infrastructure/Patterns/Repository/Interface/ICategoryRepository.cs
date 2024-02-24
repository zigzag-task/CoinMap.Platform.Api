using CoinMap.Platform.Infrastructure.Entities;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace CoinMap.Platform.Infrastructure.Patterns.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task AddRangeAsync(IEnumerable<CategoryEntity> documents);

        Task<IMongoQueryable<CategoryEntity>> ListAsync();

        Task<long> CountAsync(Expression<Func<CategoryEntity, bool>> filterExpression);
    }
}
