using AutoMapper;
using CoinMap.Platform.Infrastructure.Entities;
using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Middleware.Extensions.Factories
{
    public static class VenueDtoFactory
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IMapper _mapper;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static IList<VenueDto> ToResult(this IEnumerable<VenueEntity> entities)
        {
            return entities.Select(ToResult).ToList();
        }

        public static VenueDto ToResult(this VenueEntity entity)
        {
            return _mapper.Map<VenueDto>(entity);
        }

        public static IList<VenueEntity> FromResult(this IEnumerable<VenueDto> entities)
        {
            return entities.Select(FromResult).ToList();
        }

        public static VenueEntity FromResult(this VenueDto entity)
        {
            return _mapper.Map<VenueEntity>(entity);
        }

    }
}
