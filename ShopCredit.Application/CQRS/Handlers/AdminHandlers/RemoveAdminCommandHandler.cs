using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class RemoveAdminCommandHandler
    {
        private readonly IRepository<Admin> _repository;

        public RemoveAdminCommandHandler(IRepository<Admin> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAdminCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
