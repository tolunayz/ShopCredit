using MediatR;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;

namespace ShopCredit.Application.CQRS.Queries.CustomerQueries
{
    public class GetAccountByIdQuery:IRequest<GetAccountByIdQueryResult>
    {
        public Guid Id { get; set; }

        public GetAccountByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
