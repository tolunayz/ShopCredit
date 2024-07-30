using MediatR;
using ShopCredit.Application.CQRS.Queries.AminQueries;
using ShopCredit.Application.CQRS.Results.AdminResults;
using ShopCredit.Application.Interfaces;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Handlers.AdminHandlers
{
    public class GetAdminQueryHandler : IRequestHandler<GetAdminQuery,List<GetAdminQueryResult>>
    {
        private readonly IReadRepository<Admin> _readRepository;

        public GetAdminQueryHandler(IReadRepository<Admin> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<GetAdminQueryResult>> Handle(GetAdminQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll();
            return values.Select(x => new GetAdminQueryResult
            {
                Id = x.Id,
                AdminName = x.AdminName,
                AdminPassword = x.AdminPassword
            }).ToList();
        }
    }
}
