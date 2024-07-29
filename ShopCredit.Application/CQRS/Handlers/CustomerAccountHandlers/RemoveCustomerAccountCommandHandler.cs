using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
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
    public class RemoveCustomerAccountCommandHandler
    {
        private readonly IWriteRepository<CustomerAccount>? _writeRepository;
        private readonly IReadRepository<CustomerAccount>? _readRepository;
        private readonly IReadRepository<Customer>? _customerReadRepository;
        private readonly IWriteRepository<Customer>? _customerWriteRepository;

        public RemoveCustomerAccountCommandHandler

            (
            IWriteRepository<CustomerAccount>? writeRepository,
            IReadRepository<CustomerAccount>? readRepository
            )
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveCustomerAccountCommand command)
        {
            var value = await _readRepository.GetByIdAsync(command.Id);
            var customer = await _customerReadRepository.GetByIdAsync(command.Id);
            _writeRepository.Remove(value);
            _customerWriteRepository.Remove(customer);
            await _writeRepository.SaveAsync();
        }
       


    }
}
