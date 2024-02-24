using AutoMapper;
using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Api.Mappings
{
    public class AuthAutoMapperProfile : Profile
    {
        public AuthAutoMapperProfile()
        {
            CreateMap<LoginDto, LoginResponse>();
            CreateMap<RegisterDto, RegisterResponse>();
            CreateMap<AuthDto, AuthResponse>();
        }
    }
}