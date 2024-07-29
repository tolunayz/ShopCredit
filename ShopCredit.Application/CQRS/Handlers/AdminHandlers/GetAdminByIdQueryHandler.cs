using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.AdminResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class GetAdminByIdQueryHandler
    {
        private readonly IReadRepository<Admin> _readRepository;

        public GetAdminByIdQueryHandler(IReadRepository<Admin> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetAdminByIdQueryResult> Handle(GetAdminByIdQuery query)
        {
            var values = await _readRepository.GetByIdAsync(query.Id);
            return new GetAdminByIdQueryResult
            {
                AdminName = values.AdminName,
                AdminPassword = values.AdminPassword
            };
        }
    }
}
