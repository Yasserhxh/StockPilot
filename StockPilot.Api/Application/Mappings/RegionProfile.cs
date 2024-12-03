using AutoMapper;
using StockPilot.Api.Application.AppRegion.Queries;
using StockPilot.Domain.Entities;

namespace StockPilot.Api.Application.Mappings
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>()
                .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
                .ForMember(dest => dest.RegionNom, opt => opt.MapFrom(src => src.RegionNom));
        }
    }
}
