using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.Interfaces;
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

        public RemoveCustomerAccountCommandHandler(IReadRepository<CustomerAccount>? readRepository)
        {
            _readRepository = readRepository;
        }
        public RemoveCustomerAccountCommandHandler(IWriteRepository<CustomerAccount>? writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task Handle(RemoveCustomerAccountCommand command)
        {
            var value = await _readRepository.GetByIdAsync(command.Id);
             _writeRepository.Remove(value);
        }


    }
}
//public int AccountId { get; set; }

//public int CustomerID { get; set; }

//public Customer? Customer { get; set; }

//public DateTime DebtDate { get; set; }

//public Boolean IsPaid { get; set; }

//public required string Description { get; set; }