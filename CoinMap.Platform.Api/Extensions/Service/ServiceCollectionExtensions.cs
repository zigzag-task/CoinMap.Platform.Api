using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Api.Mappings;
using CoinMap.Platform.Api.Swagger;
using CoinMap.Platform.Api.UseCase.Class;
using CoinMap.Platform.Api.UseCase.Interface;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics.CodeAnalysis;

namespace CoinMap.Platform.Api.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            Type[] profiles = {
                typeof(CategoryAutoMapperProfile),
                typeof(VenueAutoMapperProfile),
                typeof(UserAutoMapperProfile),
                typeof(AuthAutoMapperProfile),
            };

            services.AddAutoMapper(profiles);

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IBaseUseCase<IEnumerable<CategoryResponse>>, GetAllCategory>();
            services.AddScoped<IBaseUseCase<IEnumerable<VenueResponse>>, GetAllByCategory>();
            services.AddScoped<IBaseUseCase<LoginResponse>, Login>();
            services.AddScoped<IBaseUseCase<RegisterResponse>, Registration>();

            return services;
        }

        public static IServiceCollection AddSwaggerGenOptions(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}