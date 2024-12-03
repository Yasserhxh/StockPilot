using MediatR;

namespace StockPilot.Api.Application.AppVille.Queries
{
    public class GetVilleByIdQuery : IRequest<VilleDto>
    {
        public GetVilleByIdQuery(int villeId)
        {
            VilleId = villeId;
        }

        public int VilleId { get; set; }
    }
}
