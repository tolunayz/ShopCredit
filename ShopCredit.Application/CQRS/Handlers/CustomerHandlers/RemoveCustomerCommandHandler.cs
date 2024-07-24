using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class RemoveCustomerCommandHandler
    {
        private readonly IRepository<Customer> _repository;

        public RemoveCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCustomerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }

    }
}
