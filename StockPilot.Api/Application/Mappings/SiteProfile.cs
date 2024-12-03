using AutoMapper;
using StockPilot.Api.Application.AppSite.commands;
using StockPilot.Api.Application.AppSite.Queries;
using StockPilot.Domain.Entities;

namespace StockPilot.Api.Application.Mappings
{
    public class SiteProfile : Profile
    {
        public SiteProfile() 
        {
            CreateMap<CreateSiteCommand, Site>();
            CreateMap<Site,SiteDto>();
        }
    }
}
