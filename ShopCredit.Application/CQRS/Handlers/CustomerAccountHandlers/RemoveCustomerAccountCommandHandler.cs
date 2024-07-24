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
        private readonly IRepository<CustomerAccount>? _repository;

        public RemoveCustomerAccountCommandHandler(IRepository<CustomerAccount>? repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCustomerAccountCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }


    }
}
//public int AccountId { get; set; }

//public int CustomerID { get; set; }

//public Customer? Customer { get; set; }

//public DateTime DebtDate { get; set; }

//public Boolean IsPaid { get; set; }

//public required string Description { get; set; }