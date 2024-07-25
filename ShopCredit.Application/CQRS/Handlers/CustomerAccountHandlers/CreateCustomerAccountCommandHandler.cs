﻿using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class CreateCustomerAccountCommandHandler
    {
        private readonly IWriteRepository<CustomerAccount> _writeRepository;

        public CreateCustomerAccountCommandHandler(IWriteRepository<CustomerAccount> writerRepository, IWriteRepository<Customer> customerrepository)
        {
            _writeRepository = writerRepository;
            
        }

       

        public async Task Handle(CreateCustomerAccountCommand command)
        {



            await _writeRepository.CreateAsync(new CustomerAccount
            {
                DebtDate = command.DebtDate,
                IsPaid = command.IsPaid,
                Description = command.Description,

                      
            });
        }
}

        //public DateTime DebtDate { get; set; }

        //public Boolean IsPaid { get; set; }

        //public required string Description { get; set; }

        //public virtual Customer Customer { get; set; }

        //public virtual CustomerAccPayment CustomerAccPayment { get; set; }
    }


