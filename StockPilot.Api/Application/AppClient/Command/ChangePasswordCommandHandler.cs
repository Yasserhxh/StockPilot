using MediatR;
using Microsoft.AspNetCore.Identity;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;

namespace StockPilot.Api.Application.AppClient.Command
{
    public class ChangePasswordCommandHandler:IRequestHandler<ChangePasswordCommand,Response>
    {
        private readonly IGenericRepository<Client> _clientRepository;
        private readonly IPasswordHasher<Client> _passwordHasher;

        public ChangePasswordCommandHandler(IGenericRepository<Client> clientRepository, IPasswordHasher<Client> passwordHasher)
        {
            _clientRepository = clientRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<Response> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var client = _clientRepository.GetById(request.ClientId);
            if (client == null)
            {
                return new Response
                {
                    Success = false,
                    Message = "client not found."
                };
            }
            var verificationPassword = _passwordHasher.VerifyHashedPassword(client, client.ClientPassword, request.CurrentPassword);
            if (verificationPassword != PasswordVerificationResult.Success)
            {
                return new Response
                {
                    Success = false,
                    Message = "Current password is incorrect."
                };
            }
            client.ClientPassword = _passwordHasher.HashPassword(client, request.NewPassword);

            try
            {
                _clientRepository.Update(client);
                return new Response
                {
                    Success = true,
                    Message = "password updated successfully",
                    ClientId = client.ClientId
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = $"Error updating password: {ex.Message}"
                };
            }
            
        }
    }
}
