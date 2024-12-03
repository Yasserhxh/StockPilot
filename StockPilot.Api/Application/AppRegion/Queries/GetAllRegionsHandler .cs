using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppRegion.Queries
{
    public class GetAllRegionsHandler : IRequestHandler<GetAllRegionsQuery, List<RegionDto>>
    {
        private readonly IGenericRepository<Region> _regionrepository;
        private readonly IMapper _mapper;

        public GetAllRegionsHandler(IGenericRepository<Region> regionrepository, IMapper mapper)
        {
            _regionrepository = regionrepository;
            _mapper = mapper;
        }

        public async Task<List<RegionDto>> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
        {
            var regions =  _regionrepository.GetAll();
            return _mapper.Map<List<RegionDto>>(regions);
        }
    }
}
