using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Results.CustomerResults
{
    public class GetCustomerByIdQueryResult
    {

        public Guid CustomerID { get; set; }

        public  string? Name { get; set; }

        public  string? Surname { get; set; }

        public  int? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public List<CustomerAccountResultById> CustomerAccounts { get; set; } = new List<CustomerAccountResultById>();
    }
    public class CustomerAccountResultById
    {
        public Guid AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
