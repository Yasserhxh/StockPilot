using AutoMapper;
using StockPilot.Api.Application.AppClient.Command;
using StockPilot.Api.Application.Models;
using StockPilot.Domain.Entities;

namespace StockPilot.Api.Application.Mappings
{
    public class ClientProfile : Profile
    {
        public ClientProfile() 
        {
            CreateMap<CreateClientCommand, Client>()
            .ForMember(dest => dest.ClientIsActive, opt => opt.MapFrom(src => true)) // Default value
            .ForMember(dest => dest.ClientDateCreation, opt => opt.MapFrom(src => DateOnly.FromDateTime(DateTime.Now))) // Set creation date
            .ForMember(dest => dest.ClientDateInactif, opt => opt.Ignore()); // Ignore unmapped fields

            CreateMap<Client, UserModel>()
            .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true)) // Default value
            .ForMember(dest => dest.IsAuthenticated, opt => opt.MapFrom(src => true)) 
            .ForMember(dest => dest.Token, opt => opt.Ignore()) // Token to be set later
            .ForMember(dest => dest.ExpiresAt, opt => opt.Ignore());
        }
    }
}

    

