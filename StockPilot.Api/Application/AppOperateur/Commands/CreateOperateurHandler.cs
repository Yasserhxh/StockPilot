using AutoMapper;
using MediatR;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppOperateur.Commands
{
    public class CreateOperateurHandler : IRequestHandler<CreateOperateurCommand, Response>
    {
        private readonly IGenericRepository<Operateur> _operateurrepository;
        private readonly IMapper _mapper;

        public CreateOperateurHandler(IGenericRepository<Operateur> operateurrepository, IMapper mapper)
        {
            _operateurrepository = operateurrepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateOperateurCommand request, CancellationToken cancellationToken)
        {
            var operateur = _mapper.Map<Operateur>(request);
            try
            {
                _operateurrepository.Add(operateur);
                return new Response
                {
                    Success = true,
                    Message = "operateur created successfully",
                    OperateurId = operateur.OperateurId,
                };
            }
            catch (Exception ex) 
            {
                return new Response
                {
                    Success = false,
                    Message = $"Error creating operateur :{ex.Message}",
                };
            }
        }
    }
}
