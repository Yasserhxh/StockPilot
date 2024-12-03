using MediatR;

namespace StockPilot.Api.Application.AppRegion.Queries
{
    public class GetAllRegionsQuery : IRequest<List<RegionDto>>
    {
    }
}
