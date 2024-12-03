using MediatR;

namespace StockPilot.Api.Application.AppOperateur.Commands
{
    public class CreateOperateurCommand :IRequest<Response>
    {
        public string? OperateurNom { get; set; }
        public string? OperateurPrenom { get; set; }
        public string? OperateurCin { get; set; }
        public string? OperateurUsername { get; set; }
        public string? OperateurPassword { get; set; }
        public int? OperateurSiteId { get; set; }
    }
}
