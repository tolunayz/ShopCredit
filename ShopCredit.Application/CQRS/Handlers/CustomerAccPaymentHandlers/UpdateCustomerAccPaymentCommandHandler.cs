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
    public class UpdateCustomerAccPaymentCommandHandler
    {
        private readonly IReadRepository<CustomerAccPayment> _readRepository;
        private readonly IWriteRepository<CustomerAccPayment> _writeRepository;

        public UpdateCustomerAccPaymentCommandHandler(IReadRepository<CustomerAccPayment> readRepository, IWriteRepository<CustomerAccPayment> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        public async Task Handle(UpdateCustomerAccPaymentCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.AccountID);
            values.PaymetMethodId=command.PaymetMethodId;
            values.TotalDebt=command.TotalDebt;
            values.PaidDebt=command.PaidDebt;
            values.CurrentDebt=command.CurrentDebt;

            _writeRepository.Update(values);
        }
    }
}
