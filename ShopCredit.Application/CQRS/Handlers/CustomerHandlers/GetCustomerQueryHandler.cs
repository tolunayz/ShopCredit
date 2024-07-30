using Microsoft.EntityFrameworkCore;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerQueryHandler
    {
        private readonly IReadRepository<Customer> _readRepository;


        public GetCustomerQueryHandler(IReadRepository<Customer> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<GetCustomerQueryResult>> Handle()
        {
            var customers = await _readRepository.GetAll()
                .Include(c => c.CustomerAccounts)
                .ToListAsync();

     //       query.Include(x => x.Collection)
     //       .ThenInclude(x => x.Property);
            return customers.Select(x => new GetCustomerQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Address = x.Address,
                CustomerAccounts = x.CustomerAccounts.Select(ca => new CustomerAccountResult()
                {
                    AccountId = ca.Id
                }).ToList() // CustomerAccount Id'leri ekleniyor
            }).ToList();
        }
    }
}
