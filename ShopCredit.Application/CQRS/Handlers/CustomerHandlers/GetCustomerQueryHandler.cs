using ShopCredit.Application.CQRS.Results.AdminResults;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

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

            var values = _readRepository.GetAll();
            return values.Select(x => new GetCustomerQueryResult
            {
                Id= x.Id,
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Address = x.Address

            }
            ).ToList();

            //public async Task<List<GetAdminQueryResult>> Handle()
            //{
            //    var values = _readRepository.GetAll();
            //    return values.Select(x => new GetAdminQueryResult
            //    {
            //        Id = x.Id,
            //        AdminName = x.AdminName,
            //        AdminPassword = x.AdminPassword
            //    }).ToList();
            //}
        }

    }



    }





