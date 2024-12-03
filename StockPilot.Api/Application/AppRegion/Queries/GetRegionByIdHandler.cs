using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppRegion.Queries
{
    public class GetRegionByIdHandler : IRequestHandler<GetRegionByIdQuery, RegionDto>
    {
        private readonly IGenericRepository<Region> _regionrepository;
        private IMapper _mapper;

        public GetRegionByIdHandler(IGenericRepository<Region> regionrepository, IMapper mapper)
        {
            _regionrepository = regionrepository;
            _mapper = mapper;
        }

        public async Task<RegionDto> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
        {
            var region = _regionrepository.GetById(request.RegionId);
            if (region == null)
            {
                throw new KeyNotFoundException($"Region with ID {request.RegionId} not found.");
            }
            return _mapper.Map<RegionDto>(region);
        }
    }
}
