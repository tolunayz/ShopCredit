using ShopCredit.Application.CQRS.Results.CustomerAccPaymentResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccPaymentHandlers
{
    public class GetCustomerAccPaymentQueryHandler
    {
        private readonly IReadRepository<CustomerAccPayment> _readRepository;

        public GetCustomerAccPaymentQueryHandler(IRepository<CustomerAccPayment> repository)
        {
            _readRepository = _readRepository;
        }
        public async Task<List<GetCustomerAccPaymentByIdQueryResult>> Handle()
        {
            var values =  _readRepository.GetAll();
            return values.Select(x => new GetCustomerAccPaymentByIdQueryResult
            {
               CustomerAccount=x.CustomerAccount,
               CurrentDebt=x.CurrentDebt,
               PaymetMethodId=x.PaymetMethodId,
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