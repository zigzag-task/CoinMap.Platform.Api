using CoinMap.Platform.Infrastructure.Provider.Interface;
using CoinMap.Platform.Infrastructure.Settings;
using Newtonsoft.Json;

namespace CoinMap.Platform.Infrastructure.Provider.Abstract
{
    public abstract class AsyncProvider<T> : IAsyncProvider<T> where T : class
    {
        public virtual async Task<T> GetData(ApiSettings settings) 
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(settings.Endpoint))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    var collection = JsonConvert.DeserializeObject<T>(apiResponse)!;

                    return collection;
                }
            }
        }
    }
}
