
using MediatR;
using ShopCredit.Application.CQRS.Results.AdminResults;

namespace ShopCredit.Application.CQRS.Queries.AdminQueries
{
    public class GetAdminByIdQuery : IRequest<GetAdminByIdQueryResult>
    {
        public Guid Id { get; set; }

        public GetAdminByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
