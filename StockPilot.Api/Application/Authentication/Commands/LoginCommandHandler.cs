using MediatR;
using Microsoft.IdentityModel.Tokens;
using StockPilot.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using StockPilot.Domain.IRepositories;
using StockPilot.Api.Application.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace StockPilot.Api.Application.Authentication.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserModel>
    {
        private readonly IGenericRepository<Client> _clientRepository;
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly IPasswordHasher<Client> _passwordHasher;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IGenericRepository<Client> clientRepository, IOptions<JwtSettings> jwtSettings , IPasswordHasher<Client> passwordHasher , IMapper mapper)
        {
            _clientRepository = clientRepository;
            _jwtSettings = jwtSettings;
            _passwordHasher = passwordHasher;
            _mapper = mapper;

        }

        public async Task<UserModel> Handle(LoginCommand request, CancellationToken cancellationToken )
        {
            var client = _clientRepository.GetAll().FirstOrDefault(c => c.ClientUsername == request.UserName);
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(client, client.ClientPassword, request.Password);
            if (client == null || passwordVerificationResult != PasswordVerificationResult.Success)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }
            var token = GenerateJwtToken(client);

            var result = _mapper.Map<UserModel>(client);
            result.Token = token;
            result.ExpiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.Value.ExpirationMinutes);
            return result;
            //return new UserModel
            //{
            //    Success = true,
            //    Token = token,
            //    ExpiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.Value.ExpirationMinutes),
            //    ClientId = client.ClientId,
            //    Email = client.ClientEmail,
            //    ClientAdress = client.ClientAdress,
            //    ClientNom = client.ClientNom,
            //    ClientUsername = client.ClientUsername,
            //    ClientDateCreation =client.ClientDateCreation,
            //    ClientTelephone = client.ClientTelephone,
            //    ClientIsActive = client.ClientIsActive,
            //};

        }
        private string GenerateJwtToken(Client client)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Value.SecretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,client.ClientUsername ?? ""),
                new Claim(ClaimTypes.NameIdentifier,client.ClientId.ToString()),
                new Claim(ClaimTypes.Name,client.ClientNom ?? "")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.Value.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
                    
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
