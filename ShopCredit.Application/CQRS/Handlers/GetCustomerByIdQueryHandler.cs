using ShopCredit.Application.CQRS.Queries.CustomerQueries;
using ShopCredit.Application.CQRS.Results.CustomerResult;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers
{
    public class GetCustomerByIdQueryHandler
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCustomerByIdQueryResult
            {
                CustomerID = values.CustomerID,
                Name = values.Name,
                Surname = values.Surname,
                PhoneNumber = values.PhoneNumber,
                Address = values.Address,

            };
        }
    }
}
