namespace StockPilot.Api.Application.AppSite.Queries
{
    public class SiteDto
    {
        public int SiteId { get; set; }
        public string? SiteNom { get; set; }
        public string? SiteAdress { get; set; }
        public int? SiteVilleId { get; set; }
        public int? SiteSocieteId { get; set; }
    }
}
