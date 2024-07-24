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
        private readonly IRepository<CustomerAccPayment> _repository;

        public UpdateCustomerAccPaymentCommandHandler(IRepository<CustomerAccPayment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCustomerAccPaymentCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AccountID);
            values.CustomerAccount=command.CustomerAccount;
            values.PaymetMethodId=command.PaymetMethodId;
            values.TotalDebt=command.TotalDebt;
            values.PaidDebt=command.PaidDebt;
            values.CurrentDebt=command.CurrentDebt;

            await _repository.UpdateAsync(values);
        }
    }
}
