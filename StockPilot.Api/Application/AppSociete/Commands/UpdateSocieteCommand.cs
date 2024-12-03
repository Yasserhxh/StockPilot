using MediatR;

namespace StockPilot.Api.Application.AppSociete.Commands
{
    public class UpdateSocieteCommand : IRequest<Response>
    {
        public int SocieteId { get; set; }
        public string? SocieteRs { get; set; }
        public string? SocieteIf { get; set; }
        public string? SocieteAdress { get; set; }
        public string? SocieteTelephone { get; set; }
        public int? SocieteClientId { get; set; }
        public int? SocieteVilleId { get; set; }
    }
}
