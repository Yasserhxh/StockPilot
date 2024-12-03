using Azure.Core;

namespace StockPilot.Api.Application.Models
{
    public class UserModel
    {
        public bool Success { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int ClientId { get; set; }
        public string? Email { get; set; }
        public string? ClientTelephone { get; set; }
        public string? ClientAdress { get; set; }
        public string? ClientNom { get; set; }
        public bool? ClientIsActive { get; set; }
        public DateOnly? ClientDateCreation { get; set; }
        public string? ClientUsername { get; set; }
    }
}
