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
        private readonly IReadRepository<Admin> _readRepository;
        private readonly IWriteRepository<Admin> _writeRepository;

        public RemoveAdminCommandHandler
            (
            IReadRepository<Admin> readRepository,
            IWriteRepository<Admin> writeRepository
            )
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(RemoveAdminCommand command)
        {
            var value = await _readRepository.GetByIdAsync(command.Id);
            _writeRepository.Remove(value);
            await _writeRepository.SaveAsync();
        }
    }
}
