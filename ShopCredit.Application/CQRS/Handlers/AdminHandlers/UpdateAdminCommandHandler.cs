using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class UpdateAdminCommandHandler
    {
        private readonly IReadRepository<Admin> _readRepository;
        private readonly IWriteRepository<Admin> _writeRepository;

        public UpdateAdminCommandHandler
            (
            IWriteRepository<Admin> writeRepository, 
            IReadRepository<Admin> readRepository
            )
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(UpdateAdminCommand command)
        {  
            var values = await _readRepository.GetByIdAsync(command.AdminId);
            values.AdminProperties(command.AdminName, command.AdminPassword);
            await _writeRepository.Update(values);
            await _writeRepository.SaveAsync();
        }
    }
}