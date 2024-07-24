using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Queries
{
    public class GetCustomerAccPaymentByIdQuery
    {
        public int Id { get; set; }

        public GetCustomerAccPaymentByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
