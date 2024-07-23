using ShopCredit.Application.CQRS.Commands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers
{
    public class UpdateCustomerCommandHandler
    {
        private readonly IRepository<Customer> _repository;

        public UpdateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCustomerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CustomerID);
            values.Name = command.Name;
            values.Surname = command.Surname;
            values.Email = command.Email;
            values.PhoneNumber = command.PhoneNumber;
            values.Address = command.Address;
        }
    }
}
