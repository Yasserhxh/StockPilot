using AutoMapper;
using StockPilot.Api.Application.AppSociete.Commands;
using StockPilot.Api.Application.AppSociete.Queries;
using StockPilot.Domain.Entities;

namespace StockPilot.Api.Application.Mappings
{
    public class SocieteProfile : Profile
    {
        public SocieteProfile() 
        {
            // Mapping from CreateSocieteCommand to Societé
            CreateMap<CreateSocieteCommand, Societé>()
                .ForMember(dest => dest.SocietéRs, opt => opt.MapFrom(src => src.SocieteRs))
                .ForMember(dest => dest.SocietéIf, opt => opt.MapFrom(src => src.SocieteIf))
                .ForMember(dest => dest.SocietéAdress, opt => opt.MapFrom(src => src.SocieteAdress))
                .ForMember(dest => dest.SocietéTelephone, opt => opt.MapFrom(src => src.SocieteTelephone))
                .ForMember(dest => dest.SocietéClientId, opt => opt.MapFrom(src => src.SocieteClientId))
                .ForMember(dest => dest.SocietéVilleId, opt => opt.MapFrom(src => src.SocieteVilleId));
            // Mapping from Societé to SocieteDto (for getting all and getting by ID)
            CreateMap<Societé, SocieteDto>()
                 .ForMember(dest => dest.SocieteId, opt => opt.MapFrom(src => src.SocietéId))
                 .ForMember(dest => dest.SocieteRs, opt => opt.MapFrom(src => src.SocietéRs))
                 .ForMember(dest => dest.SocieteIf, opt => opt.MapFrom(src => src.SocietéIf))
                 .ForMember(dest => dest.SocieteAdress, opt => opt.MapFrom(src => src.SocietéAdress))
                 .ForMember(dest => dest.SocieteTelephone, opt => opt.MapFrom(src => src.SocietéTelephone))
                 .ForMember(dest => dest.SocieteClientId, opt => opt.MapFrom(src => src.SocietéClientId))
                 .ForMember(dest => dest.SocieteVilleId, opt => opt.MapFrom(src => src.SocietéVilleId));

            CreateMap<UpdateSocieteCommand, Societé>()
                .ForMember(dest => dest.SocietéId, opt => opt.MapFrom(src => src.SocieteId))
                 .ForMember(dest => dest.SocietéRs, opt => opt.MapFrom(src => src.SocieteRs))
                 .ForMember(dest => dest.SocietéIf, opt => opt.MapFrom(src => src.SocieteIf))
                 .ForMember(dest => dest.SocietéAdress, opt => opt.MapFrom(src => src.SocieteAdress))
                 .ForMember(dest => dest.SocietéTelephone, opt => opt.MapFrom(src => src.SocieteTelephone))
                 .ForMember(dest => dest.SocietéClientId, opt => opt.MapFrom(src => src.SocieteClientId))
                 .ForMember(dest => dest.SocietéVilleId, opt => opt.MapFrom(src => src.SocieteVilleId)); ;

        }
    }
}
