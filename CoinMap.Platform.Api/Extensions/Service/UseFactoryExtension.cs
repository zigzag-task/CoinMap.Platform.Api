using AutoMapper;
using CoinMap.Platform.Api.Extensions.Factories;
using System.Diagnostics.CodeAnalysis;

namespace CoinMap.Platform.Api.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class UseFactoryExtension
    {
        public static void UseFactory(this WebApplication app)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            CategoryFactory.Configure(app.Services.GetService<IMapper>());
            VenueFactory.Configure(app.Services.GetService<IMapper>());
            UserFactory.Configure(app.Services.GetService<IMapper>());
            AuthFactory.Configure(app.Services.GetService<IMapper>());
#pragma warning restore CS8604 // Possible null reference argument.

        }
    }
}
