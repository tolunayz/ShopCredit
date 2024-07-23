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
    public class CreateCustomerCommandHandler
    {
        private readonly IRepository<Customer> _repository;

        public CreateCustomerCommandHandler(IRepository<Customer> repository)
        {
            this._repository = repository;
        }

        public async Task Handle(CreateCustomerCommand command)
        {
            await _repository.CreateAsync(new Customer
            {
                Name = command.Name,
                Surname = command.Surname,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email,
                Address = command.Address
            });

        }
    }
}
