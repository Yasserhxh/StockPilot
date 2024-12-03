using MediatR;
using StockPilot.Api.Application.Models;

namespace StockPilot.Api.Application.Authentication.Commands
{
    public class LoginCommand :IRequest<UserModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginCommand(string userName, string password)
                {
                    UserName = userName;
                    Password = password;
                }
    }
}
