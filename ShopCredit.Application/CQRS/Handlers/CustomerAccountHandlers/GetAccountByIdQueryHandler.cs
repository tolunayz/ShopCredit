using MediatR;
using ShopCredit.Application.CQRS.Queries.CustomerQueries;
using ShopCredit.Application.CQRS.Results.CustomerAccountResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerAccountHandlers
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, GetAccountByIdQueryResult>
    {
        private readonly IReadRepository<CustomerAccount> _readRepository;
public GetAccountByIdQueryHandler(IReadRepository<CustomerAccount> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetAccountByIdQueryResult> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
           var values = await _readRepository.GetByIdAsync(request.Id);
            return new GetAccountByIdQueryResult
            {
                AccountId = values.Id,  
                DebtDate= values.CreatedDate,
                Description = values.Description,
                IsPaid = values.IsPaid,
                CurrentDebt= values.CurrentDebt,
           

            };

        }
    }
}
