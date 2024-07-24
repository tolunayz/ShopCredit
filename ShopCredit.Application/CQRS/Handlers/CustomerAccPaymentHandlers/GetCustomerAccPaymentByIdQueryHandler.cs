using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;
using ShopCredit.Application.CQRS.Results.CustomerAccPaymentResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccPaymentHandlers
{
    public class GetCustomerAccPaymentByIdQueryHandler
    {
        private readonly IRepository<CustomerAccPayment> _repository;

        public GetCustomerAccPaymentByIdQueryHandler(IRepository<CustomerAccPayment> repository)
        {
            _repository = repository;
        }

        public async Task<GetCustomerAccPaymentByIdQueryResult> Handle(GetCustomerAccPaymentByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCustomerAccPaymentByIdQueryResult
            {
               AccountID=values.AccountID,
               CustomerAccount=values.CustomerAccount,
               CurrentDebt=values.CurrentDebt,
               PaymetMethodId=values.PaymetMethodId,
               TotalDebt=values.TotalDebt,  
               PaidDebt=values.PaidDebt
               
            };
        }
    }
}

