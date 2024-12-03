using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppSite.Queries
{
    public class GetSitesBySocieteIdQueryHandler : IRequestHandler<GetSitesBySocieteIdQuery, List<SiteDto>>
    {
        private readonly IGenericRepository<Site> _siterepository;
        private readonly IMapper _mapper;

        public GetSitesBySocieteIdQueryHandler(IGenericRepository<Site> siterepository, IMapper mapper)
        {
            _siterepository = siterepository;
            _mapper = mapper;
        }

        public async Task<List<SiteDto>> Handle(GetSitesBySocieteIdQuery request, CancellationToken cancellationToken)
        {
            var sites = _siterepository.GetAll()
                .Where(s => s.SiteSocieteId == request.Id)
                .ToList();
            return  _mapper.Map<List<SiteDto>>(sites);
        }
    }
}
