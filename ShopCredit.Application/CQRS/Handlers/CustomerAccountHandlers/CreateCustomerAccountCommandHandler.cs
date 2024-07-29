using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class CreateCustomerAccountCommandHandler
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



        public async Task Handle(CreateCustomerAccountCommand command)
        {

            var customerAccount = new CustomerAccount();
            customerAccount.CustomerAccountProperties
                (
                    command.CustomerId,
                    command.IsPaid,
                    command.Description,
                    command.Debt,
                    command.CurrentDebt,
                    command.PaidDebt
                );
            await _writeCustomerAccountRepository.CreateAsync( customerAccount );
            await _writeCustomerAccountRepository.SaveAsync();

        }

    }

}


