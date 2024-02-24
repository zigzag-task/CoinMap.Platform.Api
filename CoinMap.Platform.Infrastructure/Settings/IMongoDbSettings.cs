namespace CoinMap.Platform.Infrastructure.Settings
{
    public interface IMongoDbSettings
    {
        public string ConnectionString { get; set; }

        public string Database { get; set; }
    }
}
