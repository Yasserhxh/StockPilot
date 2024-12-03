using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppVille.Queries
{
    public class GetVilleByIdHandler : IRequestHandler<GetVilleByIdQuery, VilleDto>
    {
        private readonly IGenericRepository<Ville> _villerepository;
        private readonly IMapper _mapper;

        public GetVilleByIdHandler(IGenericRepository<Ville> villerepository, IMapper mapper)
        {
            _villerepository = villerepository;
            _mapper = mapper;
        }

        public async Task<VilleDto> Handle(GetVilleByIdQuery request, CancellationToken cancellationToken)
        {
            var ville = _villerepository.GetById(request.VilleId);
            if (ville == null)
            {
                throw new KeyNotFoundException($"Ville with ID {request.VilleId} not found.");
            }
            return _mapper.Map<VilleDto>(ville);
        }
    }
}
