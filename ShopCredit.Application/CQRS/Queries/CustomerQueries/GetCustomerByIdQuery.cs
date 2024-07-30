using MediatR;
using ShopCredit.Application.CQRS.Results.CustomerResults;

namespace ShopCredit.Application.CQRS.Queries
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdQueryResult>
    {
        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

    }
}
