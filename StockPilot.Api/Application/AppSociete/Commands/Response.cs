namespace StockPilot.Api.Application.AppSociete.Commands
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int SocieteId { get; set; }
    }
}
