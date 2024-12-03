using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppVille.Queries
{
    public class GetAllVillesHandler : IRequestHandler<GetAllVillesQuery, List<VilleDto>>
    {
        public readonly IGenericRepository<Ville> _VilleRepository;
        private IMapper _mapper;

        public GetAllVillesHandler(IGenericRepository<Ville> villeRepository, IMapper mapper)
        {
            _VilleRepository = villeRepository;
            _mapper = mapper;
        }

        public async Task<List<VilleDto>> Handle(GetAllVillesQuery request, CancellationToken cancellationToken)
        {
            var villes =  _VilleRepository.GetAll();
            return _mapper.Map<List<VilleDto>>(villes);
        }
    }
}
