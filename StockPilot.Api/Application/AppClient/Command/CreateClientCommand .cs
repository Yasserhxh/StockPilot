using MediatR;

namespace StockPilot.Api.Application.AppClient.Command
{
    public class CreateClientCommand : IRequest<Response>
    {
        public string? ClientNom { get; set; }
        public string? ClientAdress { get; set; }
        public string? ClientUsername { get; set; }
        public string? ClientEmail { get; set; }
        public string? ClientTelephone { get; set; }
        public string? ClientPassword { get; set; }
    }
}
