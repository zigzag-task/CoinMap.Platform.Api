using CoinMap.Platform.Infrastructure.Settings;

namespace CoinMap.Platform.Infrastructure.Provider.Interface
{
    public interface IAsyncProvider<T> where T : class
    {
        Task<T> GetData(ApiSettings settings);
    }
}
