using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class GetCustomerAccountByIdQueryHandler
    {
        private readonly IReadRepository<Customer> _customerRepository;
        private readonly IReadRepository<CustomerAccount> _customerAccountRepository;



        public GetCustomerAccountByIdQueryHandler
            (
            IReadRepository<CustomerAccount> customerAccountRepository,
            IReadRepository<Customer> customerRepository)
        {
            _customerAccountRepository = customerAccountRepository;
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerAccountByIdQueryResult> Handle(GetCustomerAccountByIdQuery query)
        {
            var accountList =  _customerAccountRepository.GetAll();
            var account = accountList.FirstOrDefault(x => x.Customer.Id == query.CustomerId);
            var customer = await _customerRepository.GetByIdAsync(query.CustomerId);

            return new GetCustomerAccountByIdQueryResult
            {
                AccountId = account.Id,
                Description = account.Description,
                IsPaid = account.IsPaid,
                CustomerResult = new CustomerResult
                {
                    Id = customer.Id,
                    Address = customer.Address,
                    Email = customer.Email,
                    Name = customer.Name,
                    PhoneNumber = customer.PhoneNumber,
                    Surname = customer.Surname
                },
            };
        }
    }
}