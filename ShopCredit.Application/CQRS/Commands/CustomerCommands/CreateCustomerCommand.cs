using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.CustomerCommands
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public Guid CustomerID { get; set; }

        public  string Name { get; set; }

        public  string Surname { get; set; }

        public  int PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string Address { get; set; }
    }
}
