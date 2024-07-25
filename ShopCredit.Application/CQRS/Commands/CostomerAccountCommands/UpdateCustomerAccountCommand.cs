using ShopCredit.Domain.Entities;
using ShopCredit.Entities;
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

        //public required string Name { get; set; }

        //public required string Surname { get; set; }

        //public required int PhoneNumber { get; set; }

        //public string? Email { get; set; }

        //public string? Address { get; set; }

        public DateTime DebtDate { get; set; }

        public Boolean IsPaid { get; set; }

        public required string Description { get; set; }
    }

}
//public required string Name { get; set; }

//public required string Surname { get; set; }

//public required int PhoneNumber { get; set; }

//public string? Email { get; set; }

//public string? Address { get; set; }




//public int AccountId { get; set; }

//public int CustomerID { get; set; }

//public DateTime DebtDate { get; set; }

//public Boolean IsPaid { get; set; }

//public required string Description { get; set; }

//public virtual Customer Customer { get; set; }

//public virtual CustomerAccPayment CustomerAccPayment { get; set; }