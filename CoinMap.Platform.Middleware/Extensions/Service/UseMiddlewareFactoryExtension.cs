using AutoMapper;
using CoinMap.Platform.Middleware.Extensions.Factories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CoinMap.Platform.Middleware.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class UseMiddlewareFactoryExtension
    {
        public static void UseMiddlewareFactory(this WebApplication app)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            CategoryDtoFactory.Configure(app.Services.GetService<IMapper>());
            VenueDtoFactory.Configure(app.Services.GetService<IMapper>());
#pragma warning restore CS8604 // Possible null reference argument.

        }
    }
}
