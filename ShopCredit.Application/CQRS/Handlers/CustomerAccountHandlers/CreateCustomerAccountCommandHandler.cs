using MediatR;
using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
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
            var customerAccount = new CustomerAccount();
            customerAccount.CustomerAccountProperties
            (  
                    request.IsPaid,
                    request.Description,
                    request.Debt,
                    request.CurrentDebt,
                    request.PaidDebt
                );
            await _writeCustomerAccountRepository.CreateAsync(customerAccount);
            await _writeCustomerAccountRepository.SaveAsync();
            return customerAccount.Id;

        }
    }

}


