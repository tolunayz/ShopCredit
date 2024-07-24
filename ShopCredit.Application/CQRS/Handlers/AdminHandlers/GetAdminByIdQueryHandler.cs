using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.AdminResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class GetAdminByIdQueryHandler
    {

       private  readonly IRepository<Admin> _repository;

        public GetAdminByIdQueryHandler(IRepository<Admin> repository)
        {
            _repository = repository;
        }

        public async Task<GetAdminByIdQueryResult> Handle(GetAdminByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAdminByIdQueryResult
            {
                AdminID=values.AdminId,
                AdminName=values.AdminName,
                AdminPassword=values.AdminPassword
            };
        }
    }
}
