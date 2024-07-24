using ShopCredit.Application.CQRS.Results.AdminResults;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class GetCustomerAccountQueryHandler
    {
        private readonly IRepository<CustomerAccount> _repository;

        public GetCustomerAccountQueryHandler(IRepository<CustomerAccount> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCustomerAccountByIdQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCustomerAccountByIdQueryResult
            {
                CustomerID = x.CustomerID,
                Description = x.Description,
                IsPaid = x.IsPaid,
                DebtDate = x.DebtDate,
                Customer = x.Customer,
                AccountId = x.AccountId
            }).ToList();
        }
    }
}

