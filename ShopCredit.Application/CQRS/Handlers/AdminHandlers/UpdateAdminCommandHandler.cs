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
        private readonly IReadRepository<Admin> _readRepository;
        private readonly IWriteRepository<Admin> _writeRepository;

        public UpdateAdminCommandHandler
            (
            IRepository<Admin> repository,
            IWriteRepository<Admin> writeRepository, 
            IReadRepository<Admin> readRepository
            )
        {
            _repository = repository;
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(UpdateAdminCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.AdminId);
            values.AdminName = command.AdminName;
            values.AdminPassword = command.AdminPassword;
            
            await _writeRepository.Update(values);
        }


     
    }
}
