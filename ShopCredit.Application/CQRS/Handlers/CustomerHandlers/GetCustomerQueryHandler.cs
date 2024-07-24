using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

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
                Email = x.Email,
                Address = x.Address

            }
            ).ToList();


        }



    }




}
