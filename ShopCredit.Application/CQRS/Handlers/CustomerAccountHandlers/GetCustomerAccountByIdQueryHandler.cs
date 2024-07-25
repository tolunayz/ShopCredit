using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;
using System.Security.Principal;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class GetCustomerAccountByIdQueryHandler
    {
        private readonly IReadRepository<CustomerAccount> _customerAccountRepository;
        private readonly IReadRepository<CustomerAccPayment> _customerAccountPaymentRepository;


        public GetCustomerAccountByIdQueryHandler
            (
            IReadRepository<CustomerAccount> customerAccountRepository,
            IReadRepository<CustomerAccPayment> customerAccountPaymentRepository
            )
        {
            _customerAccountRepository = customerAccountRepository;
            _customerAccountPaymentRepository = customerAccountPaymentRepository;
        }

        public async Task<GetCustomerAccountByIdQueryResult> Handle(GetCustomerAccountByIdQuery query)
        {
            var accountList = _customerAccountRepository.GetAll();
            var account = accountList.Where(x => x.CustomerID == query.CustomerId).First();
            //var paymentList = await _customerAccountPaymentRepository.GetAllAsync();
            //var payment = paymentList.Where(x=> x.AccountID == account.AccountId).First();

            return new GetCustomerAccountByIdQueryResult
            {
                AccountId = account.AccountId,
                CustomerID = account.CustomerID,
                Description = account.Description,
                Customer = account.Customer,
                DebtDate = account.DebtDate,
                IsPaid = account.IsPaid,
                //PaymentResult = new Results.CustomerAccPaymentResults.GetCustomerAccPaymentQueryResult
                //{
                //    AccountID= payment.AccountID,
                //    CurrentDebt = payment.CurrentDebt,
                //    PaymetMethod= payment.PaymetMethod,
                //    PaidDebt= payment.PaidDebt, 
                //    PaymetID= payment.PaymetID,
                //    TotalDebt = payment.TotalDebt,
                //}
            };
        }
    }
}