using AutoMapper;
using CoinMap.Platform.Api.Boundary.Request.Class;
using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Api.Mappings
{
    public class UserAutoMapperProfile : Profile
    {
        public UserAutoMapperProfile()
        {
            CreateMap<LoginQuery, UserDto>().ReverseMap();
            CreateMap<RegisterQuery, UserDto>().ReverseMap();
        }
    }
}
