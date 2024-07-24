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
    public class UpdateAdminCommandHandler
    {
        private readonly IRepository<Admin> _repository;

        public UpdateAdminCommandHandler(IRepository<Admin> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAdminCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AdminId);
            values.AdminName = command.AdminName;
            values.AdminPassword = command.AdminPassword;
            
            await _repository.UpdateAsync(values);
        }


     
    }
}
