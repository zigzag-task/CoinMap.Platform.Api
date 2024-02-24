using AutoMapper;
using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Api.Mappings
{
    public class VenueAutoMapperProfile : Profile
    {
        public VenueAutoMapperProfile()
        {
            CreateMap<VenueDto, VenueResponse>();
        }
    }
}
