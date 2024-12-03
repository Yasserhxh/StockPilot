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
        private readonly IClientRepository _clientRepository;
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly IPasswordHasher<Client> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;


        public LoginCommandHandler(IClientRepository clientRepository, IOptions<JwtSettings> jwtSettings, IPasswordHasher<Client> passwordHasher, IMapper mapper, SignInManager<User> signInManager)
        {
            _clientRepository = clientRepository;
            _jwtSettings = jwtSettings;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        /*  public async Task<UserModel> Handle(LoginCommand request, CancellationToken cancellationToken )
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

          }*/
        /// <summary>
        /// Handles the login command and generates a login response.
        /// </summary>
        /// <param name="request">The LoginCommand request.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A LoginResponse containing authentication information.</returns>
        public async Task<UserModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Find the user by username
                var user = await _clientRepository.GetUserByName(request.UserName);

                // Check if the user exists and the password is correct
                if (user != null)
                {
                    // Sign in the user
                    var res = await _signInManager.PasswordSignInAsync(user, request.Password, false, lockoutOnFailure: false);

                    // Check if the sign-in was successful
                    if (res.Succeeded)
                    {
                        // Generate a JWT token
                        var token = GenerateJwtToken(user);

                        var result = _mapper.Map<UserModel>(user);
                        result.Token = token;
                        result.ExpiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.Value.ExpirationMinutes);
                        return result;
                    }
                    return null;

                }
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private string GenerateJwtToken(User client)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Value.SecretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,client.UserName ?? ""),
                new Claim(ClaimTypes.NameIdentifier,client.Id.ToString()),
                new Claim(ClaimTypes.Name,client.FirstName ?? "")
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
