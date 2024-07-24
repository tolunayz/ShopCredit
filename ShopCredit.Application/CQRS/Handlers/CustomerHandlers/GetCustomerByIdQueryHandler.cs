using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandler
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
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
