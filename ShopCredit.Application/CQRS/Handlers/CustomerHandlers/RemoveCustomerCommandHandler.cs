using MediatR;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand>
    {

        private readonly IReadRepository<Customer> _readRepository;
        private readonly IWriteRepository<Customer> _writeRepository;

        public RemoveCustomerCommandHandler
            (
            IWriteRepository<Customer> writeRepository,
            IReadRepository<Customer> readRepository
            )
        {

            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            var value = await _readRepository.GetByIdAsync(request.Id);
            _writeRepository.Remove(value);
            await _writeRepository.SaveAsync();
        }
    }
}
