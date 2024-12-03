namespace StockPilot.Api.Application.AppClient.Command
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int ClientId { get; set; }
    }
}
