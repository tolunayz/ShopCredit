using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using System.Diagnostics;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandler
    {

        private readonly ICustomerAndAccountRepository _customerAndAccountRepository;

        public GetCustomerByIdQueryHandler
            (

            ICustomerAndAccountRepository customerAndAccountRepository
            )
        {

            _customerAndAccountRepository = customerAndAccountRepository;
        }

        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery query)
        {
            try
            {
                var values = await _customerAndAccountRepository.GetCustomerByIdWithAccountsAsync(query.Id);

                if (values == null)
                {
                    throw new KeyNotFoundException($"{query.Id} Bu Id ye sahip kullanıcı bulunamadı!");
                }

                return new GetCustomerByIdQueryResult
                {
                    CustomerID= values.Id,
                    Name = values.Name,
                    Surname = values.Surname,
                    PhoneNumber = values.PhoneNumber,
                    Email=values.Email,
                    Address = values.Address,

                    CustomerAccounts = values.CustomerAccounts.Select(ca => new CustomerAccountResultById()
                    {
                        AccountId = ca.Id,
                        CreatedDate = ca.CreatedDate,

                    }).ToList() // CustomerAccount Id'leri ekleniyor
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
