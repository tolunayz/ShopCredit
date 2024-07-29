using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System.Diagnostics;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandler
    {
        private readonly IRepository<Customer> _repository;
        private readonly IReadRepository<Customer> _readRepository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> repository, IReadRepository<Customer> readRepository)
        {
            _repository = repository;
            _readRepository = readRepository;
        }

        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery query)
        {
            try
            {
                var values = await _readRepository.GetByIdAsync(query.Id);

                if (values == null)
                {
                    throw new KeyNotFoundException($"{query.Id} Bu Id ye sahip kullanıcı bulunamadı!");
                }

                return new GetCustomerByIdQueryResult
                {
                    Name = values.Name,
                    Surname = values.Surname,
                    PhoneNumber = values.PhoneNumber,
                    Address = values.Address,
                };
            }
            catch (KeyNotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while getting the customer by ID.", ex);
            }
        }

    }
}
