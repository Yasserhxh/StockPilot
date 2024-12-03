using AutoMapper;
using MediatR;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppOperateur.Queries
{
    public class GetOperateurByIdHandler : IRequestHandler<GetOperateurByIdQuery, OperateurDto>
    {
        private readonly IGenericRepository<OperateurDto> _operateurrepository;
        private readonly IMapper _mapper;

        public GetOperateurByIdHandler(IGenericRepository<OperateurDto> operateurrepository, IMapper mapper)
        {
            _operateurrepository = operateurrepository;
            _mapper = mapper;
        }

        public async Task<OperateurDto> Handle(GetOperateurByIdQuery request, CancellationToken cancellationToken)
        {
            var operateur = _operateurrepository.GetById(request.Id);
            if (operateur == null) 
            {
                throw new KeyNotFoundException($"Operateur with ID {request.Id} not found.");
            }
            return _mapper.Map<OperateurDto>(operateur);
        }
    }
}
