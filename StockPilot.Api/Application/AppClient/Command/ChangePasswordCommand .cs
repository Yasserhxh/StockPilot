using MediatR;

namespace StockPilot.Api.Application.AppClient.Command
{
    public class ChangePasswordCommand :IRequest<Response>
    {
        public int ClientId { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
