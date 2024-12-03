namespace StockPilot.Api.Application.AppOperateur.Commands
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int OperateurId { get; set; }
    }
}
