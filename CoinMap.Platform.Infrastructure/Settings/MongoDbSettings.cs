namespace CoinMap.Platform.Infrastructure.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string Database { get; set; } = null!;
    }
}
