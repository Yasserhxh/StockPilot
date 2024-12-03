using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppClient.Command
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response>
    {
        private readonly IGenericRepository<Client> _clientRepository;
        private readonly IPasswordHasher<Client> _passwordHasher;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IGenericRepository<Client> clientRepository, IPasswordHasher<Client> passwordHasher,IMapper mapper)
        {
            _clientRepository = clientRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }
        public async Task<Response> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var existingClient = _clientRepository.GetAll()
                      .FirstOrDefault(c => c.ClientEmail == request.ClientEmail || c.ClientUsername == request.ClientUsername);

            if (existingClient != null)
            {
                return new Response
                {
                    Success = false,
                    Message = "Email already exists"
                };
            }
            var client = _mapper.Map<Client>(request);
            //var client = new Client
            //{
            //    ClientUsername = request.ClientUsername,
            //    ClientEmail = request.ClientEmail,
            //    ClientAdress = request.ClientAdress,
            //    ClientNom = request.ClientNom,
            //    ClientTelephone = request.ClientTelephone,
            //    ClientIsActive = true,
            //    ClientDateCreation = DateOnly.FromDateTime(DateTime.Now)
            //};
            client.ClientPassword = _passwordHasher.HashPassword(client, request.ClientPassword);
            try
            {
                _clientRepository.Add(client);
                return new Response
                {
                    Success = true,
                    Message = "Client created successfully",
                    ClientId = client.ClientId
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
