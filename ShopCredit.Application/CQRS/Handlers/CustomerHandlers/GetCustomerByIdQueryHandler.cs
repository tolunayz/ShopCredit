using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandler
    {
        private readonly IRepository<Customer> _repository;
        private readonly IReadRepository<Customer> _readRepository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> repository, IReadRepository<Customer> readRepository)
        {
            _repository = repository;
            _readRepository = readRepository;
        }

        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery query)
        {
            var values = await _readRepository.GetByIdAsync(query.Id);
            return new GetCustomerByIdQueryResult
            {
                CustomerID = values.CustomerID,
                Name = values.Name,
                Surname = values.Surname,
                PhoneNumber = values.PhoneNumber,
                Address = values.Address,

            };
        }
    }
}
