using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Queries
{
    public class GetAdminByIdQuery
    {
        public Guid Id { get; set; }

        public GetAdminByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
