using MediatR;

namespace StockPilot.Api.Application.AppSociete.Queries
{
    public class GetAllSocietesQuery : IRequest<List<SocieteDto>>
    {
    }
}
