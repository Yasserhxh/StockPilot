using AutoMapper;
using MediatR;
using StockPilot.Api.Application.AppClient.Command;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;
using System.Net.Sockets;

namespace StockPilot.Api.Application.AppSociete.Commands
{
    public class CreateSocieteCommandHandler : IRequestHandler<CreateSocieteCommand,Response>
    {
        private readonly IGenericRepository<Societé> _societeRepository;
        private readonly IMapper _mapper;

        public CreateSocieteCommandHandler(IGenericRepository<Societé> societeRepository, IMapper mapper)
        {
            _societeRepository = societeRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateSocieteCommand request, CancellationToken cancellationToken)
        {
            var societe = _mapper.Map<Societé>(request);

            try
            {
                _societeRepository.Add(societe);
                return new Response
                {
                    Success = true,
                    Message = "Client created successfully",
                    SocieteId = societe.SocietéId
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = $"Error creating client: {ex.Message}"
                };
            }
        }
    }
}
