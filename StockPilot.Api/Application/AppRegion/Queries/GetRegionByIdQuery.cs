using MediatR;

namespace StockPilot.Api.Application.AppRegion.Queries
{
    public class GetRegionByIdQuery : IRequest<RegionDto>
    {
        public int RegionId { get; set; }

        public GetRegionByIdQuery(int regionId)
        {
            RegionId = regionId;
        }
    }
}
