using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class UpdateCustomerAccountCommandHandler
    {
        private readonly IWriteRepository<CustomerAccount> _writeRepository;
        private readonly IReadRepository<CustomerAccount> _readRepository;
        private readonly IReadRepository<Customer> _customerReadRepository;

        public UpdateCustomerAccountCommandHandler(IWriteRepository<CustomerAccount> writeRepository, IReadRepository<CustomerAccount> readRepository, IReadRepository<Customer> customerReadRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _customerReadRepository = customerReadRepository;
        }

        public async Task Handle(UpdateCustomerAccountCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.CustomerId);
            var customer = await _customerReadRepository.GetByIdAsync(command.CustomerId);
            values.CustomerAccountProperties
                (
                command.CustomerId,
                command.IsPaid,
                command.Description,
                command.CurrentDebt,             
                command.Debt,
                command.PaidDebt
                );
           
            await _writeRepository.Update(values);
            await _writeRepository.SaveAsync();
        }
    }
}
