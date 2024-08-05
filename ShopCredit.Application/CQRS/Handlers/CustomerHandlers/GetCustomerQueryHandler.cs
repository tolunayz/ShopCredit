using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopCredit.Application.CQRS.Queries.CustomerQueries;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery,List<GetCustomerQueryResult>>
    {
        private readonly IReadRepository<Customer> _readRepository;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(IReadRepository<Customer> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCustomerQueryResult>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _readRepository.GetAll()
              .Include(c => c.CustomerAccounts)     
              .ToListAsync(cancellationToken);

            if (customer == null)
            {
                return null;
            }

            var result = _mapper.Map<List<GetCustomerQueryResult>>(customer);
            return result;

        }
    }
}
