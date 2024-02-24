using CoinMap.Platform.Infrastructure.Auth;
using CoinMap.Platform.Infrastructure.Patterns.Repository.Class;
using CoinMap.Platform.Infrastructure.Patterns.Repository.Interface;
using CoinMap.Platform.Infrastructure.Provider.Class;
using CoinMap.Platform.Infrastructure.Provider.Interface;
using CoinMap.Platform.Infrastructure.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace CoinMap.Platform.Infrastructure.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
         public static IServiceCollection AddDdManagement(this IServiceCollection services, IConfiguration configuration)
        {
            string dataBase = configuration.GetSection("MongoDbSettings")["Database"];
            string connectionString = configuration.GetSection("MongoDbSettings")["ConnectionString"];

            services.Configure<MongoDbSettings>(item =>
            {
                item.Database = dataBase;
                item.ConnectionString = connectionString;
            });

            services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddIdentity<ApplicationUser, ApplicationRole>((
                o => {
                    o.Password.RequireDigit = false;
                    o.Password.RequiredLength = 2;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequireUppercase = false;
                })).AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(connectionString, dataBase).AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddRepositoryPattern(this IServiceCollection services)
        {
            services.AddScoped<IVenueRepository, VenueRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(typeof(IApiProvider<>), typeof(ApiProvider<>));

            return services;
        }
    }
}