using MediatR;

namespace StockPilot.Api.Application.AppSociete.Queries
{
    public class GetSocieteByIdQuery : IRequest<SocieteDto>
    {
        public int Id { get; set; }

        public GetSocieteByIdQuery(int id)
        {
            Id = id;
        }
    }
}
