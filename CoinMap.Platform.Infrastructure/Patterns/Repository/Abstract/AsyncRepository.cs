using CoinMap.Platform.Infrastructure.Attributes;
using CoinMap.Platform.Infrastructure.Patterns.Repository.Interface;
using CoinMap.Platform.Infrastructure.Settings;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using System.Linq.Expressions;


namespace CoinMap.Platform.Infrastructure.Patterns.Repository.Abstract
{
    public abstract class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public AsyncRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.Database);

            this._collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }

        private protected string GetCollectionName(Type document)
        {
            var bsonCollectionAttribute = document!.GetCustomAttributes(typeof(BsonCollectionAttribute), true)!.FirstOrDefault() as BsonCollectionAttribute;

            return bsonCollectionAttribute?.CollectionName!;

        }

        public async Task InsertOneAsync(T document) => await _collection.InsertOneAsync(document).ConfigureAwait(false);

        public async Task InserManyAsync(IEnumerable<T> documents) => await _collection.InsertManyAsync(documents).ConfigureAwait(false);


        public Task<IMongoQueryable<T>> GetAll() => Task.Run(() => this._collection.AsQueryable());

        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> filterExpression) => await this._collection.Find(filterExpression).ToListAsync();

        public async Task<long> CountDocumentAsync(Expression<Func<T, bool>> filterExpression) => await this._collection.CountDocumentsAsync(filterExpression);
    }
}
