using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands
{
    public class UpdateCustomerCommand
    {
        public int CustomerID { get; set; }

        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required int PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
