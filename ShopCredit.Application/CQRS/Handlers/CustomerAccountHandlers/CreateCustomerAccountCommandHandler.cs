using MediatR;
using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.CQRS.Commands.CustomerAccountCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class CreateCustomerAccountCommandHandler : IRequestHandler<CreateCustomerAccountCommand, Guid>
    {
        private readonly IWriteRepository<CustomerAccount> _writeCustomerAccountRepository;
        private readonly IWriteRepository<Customer> _writeCustomerRepository;


        public CreateCustomerAccountCommandHandler
            (
            IWriteRepository<CustomerAccount> writeCustomerAccountRepository,
            IWriteRepository<Customer> writeCustomerRepository
            )
        {
            _writeCustomerAccountRepository = writeCustomerAccountRepository;
            _writeCustomerRepository = writeCustomerRepository;
        }

        public async Task<Guid> Handle(CreateCustomerAccountCommand request, CancellationToken cancellationToken)
        {

            var customerAccount = CustomerAccount.Create
                (
                customerId: request.CustomerId,
                description: request.Description,
                debt: request.Debt,
                paidDebt: request.PaidDebt
                );
            await _writeCustomerAccountRepository.CreateAsync(customerAccount);
            await _writeCustomerAccountRepository.SaveAsync();
            return customerAccount.Id;
        }
    }

}


