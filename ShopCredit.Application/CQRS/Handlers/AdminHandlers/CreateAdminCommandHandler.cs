using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class CreateAdminCommandHandler
    {
        private readonly IRepository<Admin> _repository;
        private readonly IWriteRepository<Admin> _writeRepository;

        public CreateAdminCommandHandler(IRepository<Admin> repository, IWriteRepository<Admin> writeRepository)
        {
            _repository = repository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateAdminCommand command)
        {
            await _writeRepository.CreateAsync(new Admin
            {
                AdminName = command.AdminName,
                AdminPassword = command.AdminPassword,
            });

        }


    }
}
