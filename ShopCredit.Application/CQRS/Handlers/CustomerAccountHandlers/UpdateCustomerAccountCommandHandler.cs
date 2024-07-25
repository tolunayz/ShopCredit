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

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class UpdateCustomerAccountCommandHandler
    {
        private readonly IWriteRepository<CustomerAccount> _writeRepository;
        private readonly IReadRepository<CustomerAccount> _readRepository;

        public UpdateCustomerAccountCommandHandler(IWriteRepository<CustomerAccount> writeRepository, IReadRepository<CustomerAccount> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(UpdateCustomerAccountCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.CustomerID);
           
            values.DebtDate= command.DebtDate;
            values.Description= command.Description;
            values.IsPaid= command.IsPaid;
           
            await _writeRepository.Update(values);
        }
    }
}

//public int AccountId { get; set; }

//public int CustomerID { get; set; }

//public required string Name { get; set; }

//public required string Surname { get; set; }

//public required int PhoneNumber { get; set; }

//public string? Email { get; set; }

//public string? Address { get; set; }

//public DateTime DebtDate { get; set; }

//public Boolean IsPaid { get; set; }

//public required string Description { get; set; }
