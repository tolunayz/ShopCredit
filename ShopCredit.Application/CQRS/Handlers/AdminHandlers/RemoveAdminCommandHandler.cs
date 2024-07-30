using MediatR;
using ShopCredit.Application.CQRS.Commands.AdminCommands;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.CQRS.Queries.AminQueries;
using ShopCredit.Application.CQRS.Results.AdminResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
