using MediatR;

namespace StockPilot.Api.Application.AppOperateur.Queries
{
    public class GetAllOperateursQuery : IRequest<List<OperateurDto>>
    {
    }
}
