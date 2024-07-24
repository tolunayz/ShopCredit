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

        public int CustomerID { get; set; }

        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required int PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
