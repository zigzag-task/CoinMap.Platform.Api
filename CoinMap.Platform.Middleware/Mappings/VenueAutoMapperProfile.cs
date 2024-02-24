using AutoMapper;
using CoinMap.Platform.Infrastructure.Entities;
using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Middleware.Mappings
{
    public class VenueAutoMapperProfile : Profile
    {
        public VenueAutoMapperProfile()
        {
            CreateMap<VenueEntity, VenueDto>().ReverseMap();
        }
    }
}
