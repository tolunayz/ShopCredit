using ShopCredit.Application.CQRS.Results;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerQueryHandler
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomerQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCustomerQueryResult>> Handle()
        {

            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCustomerQueryResult
            {
                CustomerID = x.CustomerID,
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,
                Email= x.Email,
                Adress= x.Adress

            }
            ).ToList();
           

        }



    }

    
    

}
