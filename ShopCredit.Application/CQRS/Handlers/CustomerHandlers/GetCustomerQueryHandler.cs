using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerQueryHandler
    {
        private readonly IRepository<Customer> _repository;
        private readonly IReadRepository<Customer> _readRepository;

        public GetCustomerQueryHandler(IRepository<Customer> repository, IReadRepository<Customer> readRepository)
        {
            _repository = repository;
            _readRepository = readRepository;
        }

        public async Task<List<GetCustomerQueryResult>> Handle()
        {

            var values = _readRepository.GetAll();
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
