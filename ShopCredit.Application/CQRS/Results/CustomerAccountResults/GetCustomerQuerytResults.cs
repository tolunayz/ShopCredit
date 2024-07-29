using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Results.CustomerAccountResults
{
    public class GetCustomerQuerytResults
    {
        public Guid AccountId { get; set; }

        public int CustomerID { get; set; }

        public Customer? Customer { get; set; }

        public DateTime DebtDate { get; set; }

        public Boolean IsPaid { get; set; }

        public  string Description { get; set; }
    }
}
