using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.AdminResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class GetAdminByIdQueryHandler
    {

       private  readonly IRepository<Admin> _repository;
        private readonly IWriteRepository<Admin> _writeRepository;
        private readonly IReadRepository<Admin> _readRepository;

        public GetAdminByIdQueryHandler(IRepository<Admin> repository, IWriteRepository<Admin> writeRepository, IReadRepository<Admin> readRepository)
        {
            _repository = repository;
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<GetAdminByIdQueryResult> Handle(GetAdminByIdQuery query)
        {
            var values = await _readRepository.GetByIdAsync(query.Id);
            return new GetAdminByIdQueryResult
            {
                AdminID=values.AdminId,
                AdminName=values.AdminName,
                AdminPassword=values.AdminPassword
            };
        }
    }
}
