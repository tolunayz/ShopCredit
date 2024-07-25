using ShopCredit.Application.CQRS.Commands.CostomerAccountCommands;
using ShopCredit.Application.CQRS.Commands.CustomerAccPaymentCommands;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccPaymentHandlers
{
    public class RemoveCustomerAccPaymentCommandHandler
    {
        private readonly IWriteRepository<CustomerAccPayment> _writeRepository;
        private readonly IReadRepository<CustomerAccPayment> _readRepository;

        public RemoveCustomerAccPaymentCommandHandler
        (
            IWriteRepository<CustomerAccPayment> writeRepository, 
            IReadRepository<CustomerAccPayment> readRepository
        )
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveCustomerAccPaymentCommand command)
        {
            var value = await _readRepository.GetByIdAsync(command.Id);
             _writeRepository.Remove(value);
        }
    }
}
