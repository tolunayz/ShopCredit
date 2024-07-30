using MediatR;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;

namespace ShopCredit.Application.CQRS.Queries
{
    public class GetCustomerAccountByIdQuery : IRequest<GetCustomerAccountByIdQueryResult>
    {
        public Guid CustomerId { get; set; }

        public GetCustomerAccountByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
