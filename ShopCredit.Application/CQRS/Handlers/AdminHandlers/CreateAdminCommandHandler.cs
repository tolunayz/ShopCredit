using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class CreateAdminCommandHandler
    {
        private readonly IRepository<Admin> _repository;

        public CreateAdminCommandHandler(IRepository<Admin> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAdminCommand command)
        {
            await _repository.CreateAsync(new Admin
            {
                AdminName = command.AdminName,
                AdminPassword = command.AdminPassword,
            });

        }


    }
}
