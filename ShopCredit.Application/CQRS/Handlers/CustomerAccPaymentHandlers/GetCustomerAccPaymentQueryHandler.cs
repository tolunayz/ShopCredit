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
    public class GetCustomerAccPaymentQueryHandler
    {
        private readonly IRepository<CustomerAccPayment> _repository;

        public GetCustomerAccPaymentQueryHandler(IRepository<CustomerAccPayment> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCustomerAccPaymentByIdQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCustomerAccPaymentByIdQueryResult
            {
               CustomerAccount=x.CustomerAccount,
               CurrentDebt=x.CurrentDebt,
               PaymetMethodId=x.PaymetMethodId,
               PaymetID = x.PaymetID,
               PaidDebt=x.PaidDebt,
               AccountID=x.AccountID,
               TotalDebt = x.TotalDebt  

            }).ToList();
        }
    }
}
//public async Task<List<GetCustomerAccountByIdQueryResult>> Handle()
//{
//    var values = await _repository.GetAllAsync();
//    return values.Select(x => new GetCustomerAccountByIdQueryResult
//    {
//        CustomerID = x.CustomerID,
//        Description = x.Description,
//        IsPaid = x.IsPaid,
//        DebtDate = x.DebtDate,
//        Customer = x.Customer

//    }).ToList();
//}