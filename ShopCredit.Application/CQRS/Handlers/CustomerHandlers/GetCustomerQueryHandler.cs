using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopCredit.Application.CQRS.Queries.CustomerQueries;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerQueryResult>
    {
        private readonly IReadRepository<Customer> _readRepository;

        public GetCustomerQueryHandler(IReadRepository<Customer> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetCustomerQueryResult> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _readRepository.GetAll()
              .Include(c => c.CustomerAccounts)
              .FirstOrDefaultAsync();

            if (customer == null)
            {
                return null; // veya uygun bir hata durumu döndürebilirsiniz
            }

            return new GetCustomerQueryResult
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                Address = customer.Address,
                CustomerAccounts = customer.CustomerAccounts.Select(ca => new CustomerAccountResult
                {
                    AccountId = ca.Id
                }).ToList()
            };
        }
    }
}
