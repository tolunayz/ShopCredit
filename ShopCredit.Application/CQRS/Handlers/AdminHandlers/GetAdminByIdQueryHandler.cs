using MediatR;
using ShopCredit.Application.CQRS.Queries.AdminQueries;
using ShopCredit.Application.CQRS.Results.AdminResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, GetAdminByIdQueryResult>
    {
        private readonly IReadRepository<Admin> _readRepository;

        public GetAdminByIdQueryHandler(IReadRepository<Admin> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetAdminByIdQueryResult> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id);
            return new GetAdminByIdQueryResult
            {
                AdminName = values.AdminName,
                AdminPassword = values.AdminPassword
            };
        }
    }
}
