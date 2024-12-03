using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppSociete.Queries
{
    public class GetAllSocietesHandler : IRequestHandler<GetAllSocietesQuery,List<SocieteDto>>
    {
        private readonly IGenericRepository<Societé> _societerepository;
        private readonly IMapper _mapper;

        public GetAllSocietesHandler(IGenericRepository<Societé> societerepository, IMapper mapper)
        {
            _societerepository = societerepository;
            _mapper = mapper;
        }

        public async Task<List<SocieteDto>> Handle(GetAllSocietesQuery request , CancellationToken cancellationToken)
        {
            var societes = _societerepository.GetAll();
            return _mapper.Map<List<SocieteDto>>(societes);
        }
    }
}
