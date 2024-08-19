using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopCredit.Application.CQRS.Queries.CustomerAccountQueries;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class GetCustomerAccountQueryHandler : IRequestHandler<GetCustomerAccountQuery, List<GetCustomerAccountQuerytResults>>
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

        public async Task<List<GetCustomerAccountQuerytResults>> Handle(GetCustomerAccountQuery request, CancellationToken cancellationToken)
        {
            var accounts = _readRepository.GetAll();
            var customers = _customerReadRepository.GetAll();

            return await accounts.Select(x => new GetCustomerAccountQuerytResults
            {
                AccountId = x.Id,
                Description = x.Description,
                IsPaid = x.IsPaid,
                Debt = x.Debt,
                PaidDebt = x.PaidDebt,
                CurrentDebt = x.CurrentDebt,
                Customer = new CustomerResults          
                {
                    Id = x.Customer.Id,
                    Address = x.Customer.Address,
                    Email = x.Customer.Email,
                    Name = x.Customer.Name,
                    PhoneNumber = x.Customer.PhoneNumber,
                    Surname = x.Customer.Surname
                }
            }).ToListAsync();
        }
    }
}
