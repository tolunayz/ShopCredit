using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Results.CustomerAccPaymentResults
{
    public class GetCustomerAccPaymentQueryResult
    {
        public int PaymetID { get; set; }

        public int AccountID { get; set; }

        public required string PaymetMethod { get; set; }

        public long TotalDebt { get; set; }

        public long PaidDebt { get; set; }

        public required long CurrentDebt { get; set; }
    }
}
