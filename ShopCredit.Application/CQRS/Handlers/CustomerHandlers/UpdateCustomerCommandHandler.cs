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
    public class UpdateCustomerCommandHandler
    {
        private readonly IRepository<Customer> _repository;
        private readonly IWriteRepository<Customer> _writeRepository;
        private readonly IReadRepository<Customer> _readRepository;

        public UpdateCustomerCommandHandler
            (IRepository<Customer> repository, 
            IReadRepository<Customer> readRepository,
            IWriteRepository<Customer> writeRepository
            )
        {
            _repository = repository;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        public async Task Handle(UpdateCustomerCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.CustomerID);
            values.Name = command.Name;
            values.Surname = command.Surname;
            values.Email = command.Email;
            values.PhoneNumber = command.PhoneNumber;
            values.Address = command.Address;
            await _writeRepository.Update(values);
        }
    }
}
