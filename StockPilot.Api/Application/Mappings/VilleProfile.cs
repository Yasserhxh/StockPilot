using AutoMapper;
using StockPilot.Api.Application.AppVille.Queries;
using StockPilot.Domain.Entities;

namespace StockPilot.Api.Application.Mappings
{
    public class VilleProfile : Profile
    {
        public VilleProfile() 
        {
            CreateMap<Ville, VilleDto>()
                .ForMember(dest => dest.VilleId, opt => opt.MapFrom(src => src.VilleId))
                .ForMember(dest => dest.VilleNom, opt => opt.MapFrom(src => src.VilleNom))
                .ForMember(dest => dest.VilleRegionId, opt => opt.MapFrom(src => src.VilleRegionId));
        }
    }
}
