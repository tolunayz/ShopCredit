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
    public class CreateCustomerAccPaymentCommandHandler
    {
        private readonly IRepository<CustomerAccPayment> _repository;

        public CreateCustomerAccPaymentCommandHandler(IRepository<CustomerAccPayment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCustomerAccPaymentCommand command)
        {
            await _repository.CreateAsync(new CustomerAccPayment
            {
                PaidDebt = command.PaidDebt,
                CurrentDebt = command.CurrentDebt,
                PaymetMethodId = command.PaymetMethodId,
                AccountID = command.AccountID,
                TotalDebt = command.TotalDebt,  
                CustomerAccount = command.CustomerAccount
               
            });
        }
    }
}
 //public int PaymetID { get; set; }
 //       public int AccountID { get; set; }
 //       public CustomerAccount? CustomerAccount { get; set; }
 //       public required string PaymetMethod { get; set; }
 //       public long TotalDebt { get; set; }
 //       public long PaidDebt { get; set; }
 //       public required long CurrentDebt { get; set; }