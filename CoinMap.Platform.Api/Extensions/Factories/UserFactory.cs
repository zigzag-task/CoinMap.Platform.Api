using AutoMapper;
using CoinMap.Platform.Api.Boundary.Request.Class;
using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Api.Extensions.Factories
{
    public static class UserFactory
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IMapper _mapper;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static UserDto ToRequest(this RegisterQuery model)
        {
            return _mapper.Map<UserDto>(model);
        }

        public static UserDto ToRequest(this LoginQuery model)
        {
            return _mapper.Map<UserDto>(model);
        }
    }
}
