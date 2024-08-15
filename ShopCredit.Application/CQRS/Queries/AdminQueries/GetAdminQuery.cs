using MediatR;
using ShopCredit.Application.CQRS.Results.AdminResults;

namespace ShopCredit.Application.CQRS.Queries.AdminQueries
{
    public class GetAdminQuery: IRequest<List<GetAdminQueryResult>>
    {
        public GetAdminQuery()
        {
                
        }
    }
}
