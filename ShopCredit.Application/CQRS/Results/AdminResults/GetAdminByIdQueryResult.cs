using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Results.AdminResults
{
    public class GetAdminByIdQueryResult
    {
        public  string? AdminName { get; set; }
        public  string? AdminPassword { get; set; }
    }
}
