using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppSite.commands
{
    public class CreateSiteHandler : IRequestHandler<CreateSiteCommand, Response>
    {
        private readonly IGenericRepository<Site> _siterepository;
        private readonly IMapper _mapper;

        public CreateSiteHandler(IGenericRepository<Site> siterepository, IMapper mapper)
        {
            _siterepository = siterepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
        {
            var site = _mapper.Map<Site>(request);

            try
            {
                _siterepository.Add(site); 
                return new Response
                {
                    Success = true,
                    Message = "Site created successfully",
                    SiteId = site.SiteId,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = $"Error creating site: {ex.Message}"
                };
            }
        }
    }
}
