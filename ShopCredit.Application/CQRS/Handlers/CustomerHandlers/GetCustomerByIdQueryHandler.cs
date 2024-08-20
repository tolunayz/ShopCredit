using MediatR;
using ShopCredit.Application.CQRS.Queries;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResult>
    {

        private readonly ICustomerAndAccountRepository _customerAndAccountRepository;

        public GetCustomerByIdQueryHandler
            (

            ICustomerAndAccountRepository customerAndAccountRepository
            )
        {

            _customerAndAccountRepository = customerAndAccountRepository;
        }

        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var values = await _customerAndAccountRepository.GetCustomerByIdWithAccountsAsync(request.Id);

                if (values == null)
                {
                    throw new KeyNotFoundException($"{request.Id} Bu Id ye sahip kullanıcı bulunamadı!");
                }

                return new GetCustomerByIdQueryResult
                {
                    CustomerID = values.Id,
                    Name = values.Name,
                    Surname = values.Surname,
                    PhoneNumber = values.PhoneNumber,
                    Email = values.Email,
                    Address = values.Address,

                    CustomerAccounts = values.CustomerAccounts.Select(ca => new CustomerAccountResultById()
                    {
                        AccountId = ca.Id,
                        CreatedDate = ca.CreatedDate,

                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Id'ye göre customer çağırılamadı", ex);
            }
        }
    }
}
