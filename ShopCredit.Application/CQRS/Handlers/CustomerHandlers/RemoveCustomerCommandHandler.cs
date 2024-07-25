using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class RemoveCustomerCommandHandler
    {
        private readonly IRepository<Customer> _repository;
        private readonly IReadRepository<Customer> _readRepository;
        private readonly IWriteRepository<Customer> _writeRepository;

        public RemoveCustomerCommandHandler
            (IRepository<Customer> repository,
            IWriteRepository<Customer> writeRepository, 
            IReadRepository<Customer> readRepository
            )
        {
            _repository = repository;
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveCustomerCommand command)
        {
            var value = await _readRepository.GetByIdAsync(command.Id);
             _writeRepository.Remove(value);
        }

    }
}
