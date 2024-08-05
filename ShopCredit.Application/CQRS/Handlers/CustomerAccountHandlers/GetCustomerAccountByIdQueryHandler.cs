using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class GetCustomerAccountByIdQueryHandler : IRequestHandler<GetCustomerAccountByIdQuery, GetCustomerAccountByIdQueryResult>
    {
        private readonly IReadRepository<Customer> _customerRepository;
        private readonly IReadRepository<CustomerAccount> _customerAccountRepository;

        public GetCustomerAccountByIdQueryHandler(
            IReadRepository<CustomerAccount> customerAccountRepository,
            IReadRepository<Customer> customerRepository)
        {
            _customerAccountRepository = customerAccountRepository;
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerAccountByIdQueryResult> Handle(GetCustomerAccountByIdQuery request, CancellationToken cancellationToken)
        {
            // Eager loading: Customer property of CustomerAccount
            var account = await _customerAccountRepository.GetAll()
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Customer.Id == request.CustomerId, cancellationToken);

            if (account == null)
            {
                throw new NullReferenceException("Account not found.");
            }

            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new NullReferenceException("Customer not found.");
            }

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
