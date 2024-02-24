using CoinMap.Platform.Middleware.Mappings;
using CoinMap.Platform.Middleware.Patterns.Proxy.Class;
using CoinMap.Platform.Middleware.Patterns.Proxy.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CoinMap.Platform.Middleware.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMiddlewareAutoMapperProfiles(this IServiceCollection services)
        {
            Type[] profiles = {
                typeof(CategoryAutoMapperProfile),
                typeof(VenueAutoMapperProfile),
            };

            services.AddAutoMapper(profiles);

            return services;
        }
        public static IServiceCollection AddProxyPattern(this IServiceCollection services)
        {
            services.AddScoped<ICategoryProxy, CategoryProxy>();
            services.AddScoped<IVenueProxy, VenueProxy>();
            services.AddScoped<IAuthProxy, AuthProxy>();

            return services;
        }
    }
}
