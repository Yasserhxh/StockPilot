using MediatR;

namespace StockPilot.Api.Application.AppOperateur.Queries
{
    public class GetOperateurByIdQuery : IRequest<OperateurDto>
    {
        public GetOperateurByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }  
    }
}
