using CoinMap.Platform.Infrastructure.Entities;
using CoinMap.Platform.Infrastructure.Patterns.Repository.Abstract;
using CoinMap.Platform.Infrastructure.Patterns.Repository.Interface;
using CoinMap.Platform.Infrastructure.Settings;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace CoinMap.Platform.Infrastructure.Patterns.Repository.Class
{
    public class CategoryRepository : AsyncRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(IMongoDbSettings settings) : base(settings)
        {
        }

        public async Task AddRangeAsync(IEnumerable<CategoryEntity> documents) => await InserManyAsync(documents);

        public async Task<IMongoQueryable<CategoryEntity>> ListAsync() => await GetAll();

        public async Task<long> CountAsync(Expression<Func<CategoryEntity, bool>> filterExpression) => await CountDocumentAsync(filterExpression);
    }
}
