using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppSociete.Queries
{
    public class GetSocieteByIdHandler : IRequestHandler<GetSocieteByIdQuery,SocieteDto>
    {
        private readonly IGenericRepository<Societé> _societerepository;
        private readonly IMapper _mapper;

        public GetSocieteByIdHandler(IGenericRepository<Societé> societerepository, IMapper mapper)
        {
            _societerepository = societerepository;
            _mapper = mapper;
        }

        public async Task<SocieteDto> Handle(GetSocieteByIdQuery request, CancellationToken cancellationToken)
        {
            var societe = _societerepository.GetById(request.Id);
            if (societe == null)
            {
                throw new KeyNotFoundException("Societé not found");
            }

            return _mapper.Map<SocieteDto>(societe);
        }
    }
}
