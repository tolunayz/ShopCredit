using MediatR;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;

namespace ShopCredit.Application.CQRS.Queries.CustomerAccountQueries
{
    public class GetCustomerAccountQuery : IRequest<List<GetCustomerAccountQuerytResults>>
    {
        public GetCustomerAccountQuery()
        {
                
        }
    }
}
