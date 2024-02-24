using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace CoinMap.Platform.Infrastructure.Patterns.Repository.Interface
{
    public interface IAsyncRepository<T> where T : class
    {
        Task InsertOneAsync(T document);

        Task InserManyAsync(IEnumerable<T> documents);

        Task<IMongoQueryable<T>> GetAll();

        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> filterExpression);

        Task<long> CountDocumentAsync(Expression<Func<T, bool>> filterExpression);
    }
}
