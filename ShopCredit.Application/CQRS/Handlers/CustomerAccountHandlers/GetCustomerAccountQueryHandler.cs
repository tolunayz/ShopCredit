using ShopCredit.Application.CQRS.Results.CustomerAccountResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class GetCustomerAccountQueryHandler
    {
        private readonly IReadRepository<CustomerAccount> _readRepository;
        private readonly IReadRepository<Customer> _customerReadRepository;

        public GetCustomerAccountQueryHandler
            (
            IReadRepository<CustomerAccount> readRepository,
            IReadRepository<Customer> customerReadRepository)
        {
            _readRepository = readRepository;
            _customerReadRepository = customerReadRepository;
        }

        public async Task<List<GetCustomerAccountByIdQueryResult>> Handle()
        {
            var accounts = _readRepository.GetAll();
            var customers = _customerReadRepository.GetAll();

            return accounts.Select(x => new GetCustomerAccountByIdQueryResult
            {
               
                AccountId = x.Id,
                Description = x.Description,
                IsPaid = x.IsPaid,
                CustomerResult = new CustomerResult
                {
                    Id = x.Customer.Id,
                    Address = x.Customer.Address,
                    Email = x.Customer.Email,
                    Name = x.Customer.Name,
                    PhoneNumber = x.Customer.PhoneNumber,
                    Surname = x.Customer.Surname
                },
            }).ToList();
        }
    }
}