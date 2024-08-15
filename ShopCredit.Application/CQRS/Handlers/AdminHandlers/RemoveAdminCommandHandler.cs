using MediatR;
using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class RemoveAdminCommandHandler : IRequestHandler<RemoveAdminCommand>
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

        //public async Task Handle(RemoveAdminCommand command)
        //{
        //    var value = await _readRepository.GetByIdAsync(command.Id);
        //    _writeRepository.Remove(value);
        //    await _writeRepository.SaveAsync();
        //}

        public async Task Handle(RemoveAdminCommand request, CancellationToken cancellationToken)
        {
            var value = await _readRepository.GetByIdAsync(request.Id);
            _writeRepository.Remove(value);
            await _writeRepository.SaveAsync();
        }
    }
}
