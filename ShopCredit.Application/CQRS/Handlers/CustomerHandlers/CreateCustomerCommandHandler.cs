using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.CQRS.Commands.CustomerCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class CreateCustomerCommandHandler
    {
        private readonly IRepository<Customer> _repository;

        public CreateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
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
        //public CreateCustomerAccountCommandHandler(IRepository<CustomerAccount> repository)
        //{
        //    _repository = repository;
        //}

        //public async Task Handle(CreateCustomerAccountCommand command)
        //{
        //    await _repository.CreateAsync(new CustomerAccount
        //    {
        //        Customer = command.Customer,
        //        DebtDate = command.DebtDate,
        //        IsPaid = command.IsPaid,
        //        Description = command.Description

        //    });
        //}
    }
}
