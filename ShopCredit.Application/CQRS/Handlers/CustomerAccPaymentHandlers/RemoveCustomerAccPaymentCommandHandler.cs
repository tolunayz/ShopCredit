using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.CQRS.Commands.CustomerAccPaymentCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccPaymentHandlers
{
    public class RemoveCustomerAccPaymentCommandHandler
    {
        private readonly IRepository<CustomerAccPayment> _repository;

        public RemoveCustomerAccPaymentCommandHandler(IRepository<CustomerAccPayment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCustomerAccPaymentCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
