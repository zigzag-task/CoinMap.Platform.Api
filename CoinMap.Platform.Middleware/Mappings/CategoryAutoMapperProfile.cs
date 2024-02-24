using AutoMapper;
using CoinMap.Platform.Infrastructure.Entities;
using CoinMap.Platform.Middleware.Dto;

namespace CoinMap.Platform.Middleware.Mappings
{
    public class CategoryAutoMapperProfile : Profile
    {
        public CategoryAutoMapperProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
        }
    }
}
