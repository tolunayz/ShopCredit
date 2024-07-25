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
    public class GetAdminQueryHandler
    {
        private readonly IRepository<Admin> _repository;
        private readonly IReadRepository<Admin> _readRepository;

        public GetAdminQueryHandler(IRepository<Admin> repository, IReadRepository<Admin> readRepository)
        {
            _repository = repository;
            _readRepository = readRepository;
        }

        public async Task<List<GetAdminQueryResult>> Handle()
        {
            var values = _readRepository.GetAll();
            return values.Select(x => new GetAdminQueryResult
            {
                AdminID = x.AdminId,
                AdminName = x.AdminName,
                AdminPassword = x.AdminPassword
            }).ToList();
        }
    }
}
