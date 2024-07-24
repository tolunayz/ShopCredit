using ShopCredit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.CostomerAccountCommands
{
    public class UpdateCustomerAccountCommand
    {
        public int AccountId { get; set; }

        public int CustomerID { get; set; }

        public Customer? Customer { get; set; }

        public DateTime DebtDate { get; set; }

        public Boolean IsPaid { get; set; }

        public required string Description { get; set; }
    }
}
