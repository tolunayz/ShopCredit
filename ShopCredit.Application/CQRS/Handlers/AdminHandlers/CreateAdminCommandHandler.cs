using MediatR;
using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, Guid>
    {
        private readonly IWriteRepository<Admin> _writeRepository;

        public CreateAdminCommandHandler(IWriteRepository<Admin> writeRepository)
        {
            _writeRepository = writeRepository;
        }

  

         public async Task<Guid> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = new Admin();
            admin.AdminProperties(
                request.AdminName,
                request.AdminPassword
            );
            await _writeRepository.CreateAsync(admin);
            await _writeRepository.SaveAsync();
            return admin.Id;
        }
    }
}
