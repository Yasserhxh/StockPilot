using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppOperateur.Queries
{
    public class GetAllOperateursHandler : IRequestHandler<GetAllOperateursQuery, List<OperateurDto>>
    {
        private readonly IGenericRepository<Operateur> _operateurrepository;
        private readonly IMapper _mapper;

        public GetAllOperateursHandler(IGenericRepository<Operateur> operateurrepository, IMapper mapper)
        {
            _operateurrepository = operateurrepository;
            _mapper = mapper;
        }

        public async Task<List<OperateurDto>> Handle(GetAllOperateursQuery request, CancellationToken cancellationToken)
        {
            var operateurs = _operateurrepository.GetAll();
            return  _mapper.Map<List<OperateurDto>>(operateurs);
        }
    }
}
