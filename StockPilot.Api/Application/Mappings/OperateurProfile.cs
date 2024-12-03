using AutoMapper;
using StockPilot.Api.Application.AppOperateur.Commands;
using StockPilot.Api.Application.AppOperateur.Queries;
using StockPilot.Domain.Entities;

namespace StockPilot.Api.Application.Mappings
{
    public class OperateurProfile : Profile 
    {
        public OperateurProfile() 
        {
            CreateMap<CreateOperateurCommand,Operateur>();
            CreateMap<Operateur,OperateurDto>();
        }
    }
}
