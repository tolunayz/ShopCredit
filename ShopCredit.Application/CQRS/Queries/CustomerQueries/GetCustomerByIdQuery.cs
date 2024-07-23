using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Queries.CustomerQueries
{
    public class GetCustomerByIdQuery
    {
        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
