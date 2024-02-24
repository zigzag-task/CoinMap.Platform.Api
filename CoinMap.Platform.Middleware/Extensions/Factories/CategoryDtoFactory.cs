using AutoMapper;
using CoinMap.Platform.Infrastructure.Entities;
using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Middleware.Extensions.Factories
{
    public static class CategoryDtoFactory
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IMapper _mapper;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static IList<CategoryDto> ToResult(this IEnumerable<CategoryEntity> entities)
        {
            return entities.Select(ToResult).ToList();
        }

        public static CategoryDto ToResult(this CategoryEntity entity)
        {
            return _mapper.Map<CategoryDto>(entity);
        }

        public static IList<CategoryEntity> FromResult(this IEnumerable<CategoryDto> entities)
        {
            return entities.Select(FromResult).ToList();
        }

        public static CategoryEntity FromResult(this CategoryDto entity)
        {
            return _mapper.Map<CategoryEntity>(entity);
        }
    }
}
