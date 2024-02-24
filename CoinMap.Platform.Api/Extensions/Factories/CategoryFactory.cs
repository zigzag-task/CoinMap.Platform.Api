using AutoMapper;
using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Api.Extensions.Factories
{
    public static class CategoryFactory
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IMapper _mapper;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static IEnumerable<CategoryResponse> ToResponse(this IEnumerable<CategoryDto> model)
        {
            return model.Select(ToResponse);
        }

        public static CategoryResponse ToResponse(this CategoryDto model)
        {
            return _mapper.Map<CategoryResponse>(model);
        }
    }
}
