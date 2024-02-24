using CoinMap.Platform.Infrastructure.Provider.Abstract;
using CoinMap.Platform.Infrastructure.Provider.Interface;
using CoinMap.Platform.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;


namespace CoinMap.Platform.Infrastructure.Provider.Class
{
    public class ApiProvider<T> : AsyncProvider<T>, IApiProvider<T> where T : class
    {
        private readonly ApiSettings _apiSettings;

        public ApiProvider(IConfiguration config) 
        {
            this._apiSettings = config.GetSection("ApiSettings").Get<ApiSettings>();
        }

        public async Task<T> ListAsync() => await GetData(this._apiSettings);
    }
}
