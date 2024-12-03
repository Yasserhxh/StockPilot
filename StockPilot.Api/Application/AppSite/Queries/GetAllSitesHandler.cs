using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppSite.Queries
{
    public class GetAllSitesHandler : IRequestHandler<GetAllSitesQuery, List<SiteDto>>
    {
        private readonly IGenericRepository<Site> _siterepository;
        private readonly IMapper _mapper;

        public GetAllSitesHandler(IGenericRepository<Site> siterepository, IMapper mapper)
        {
            _siterepository = siterepository;
            _mapper = mapper;
        }

        public async Task<List<SiteDto>> Handle(GetAllSitesQuery request, CancellationToken cancellationToken)
        {
            var sites = _siterepository.GetAll();
            return _mapper.Map<List<SiteDto>>(sites);
            
        }
    }
}
