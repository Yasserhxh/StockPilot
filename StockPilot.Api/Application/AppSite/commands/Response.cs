namespace StockPilot.Api.Application.AppSite.commands
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int SiteId { get; set; }
    }
}
