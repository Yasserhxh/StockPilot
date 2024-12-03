using MediatR;

namespace StockPilot.Api.Application.AppSite.Queries
{
    public class GetSitesBySocieteIdQuery : IRequest<List<SiteDto>>
    {
        public GetSitesBySocieteIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
