using MediatR;

namespace StockPilot.Api.Application.AppSite.commands
{
    public class CreateSiteCommand : IRequest<Response>
    {
        public string? SiteNom { get; set; }
        public string? SiteAdress { get; set; }
        public int? SiteVilleId { get; set; }
        public int? SiteSocieteId { get; set; }
    }
}
