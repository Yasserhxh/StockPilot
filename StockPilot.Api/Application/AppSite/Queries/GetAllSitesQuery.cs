using MediatR;

namespace StockPilot.Api.Application.AppSite.Queries
{
    public class GetAllSitesQuery :IRequest<List<SiteDto>>
    {
    }
}
