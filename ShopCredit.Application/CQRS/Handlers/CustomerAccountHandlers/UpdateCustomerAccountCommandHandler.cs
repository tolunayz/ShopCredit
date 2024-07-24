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
        private readonly IRepository<CustomerAccount> _repository;

        public UpdateCustomerAccountCommandHandler(IRepository<CustomerAccount> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCustomerAccountCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CustomerID);
            values.Customer= command.Customer;
            values.DebtDate= command.DebtDate;
            values.Description= command.Description;
            values.IsPaid= command.IsPaid;
           
            await _repository.UpdateAsync(values);
        }
    }
}
//public int AccountId { get; set; }

//public int CustomerID { get; set; }

//public Customer? Customer { get; set; }

//public DateTime DebtDate { get; set; }

//public Boolean IsPaid { get; set; }

//public required string Description { get; set; }
