namespace CoinMap.Platform.Infrastructure.Provider.Interface
{
    public interface IApiProvider<T> where T : class
    {
        Task<T> ListAsync();
    }
}
