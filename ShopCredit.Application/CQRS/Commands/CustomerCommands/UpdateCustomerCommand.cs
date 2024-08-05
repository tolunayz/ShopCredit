using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.CustomerCommands
{
    public class UpdateCustomerCommand : IRequest
    {
        public UpdateCustomerCommand(Guid customerID, string? name, string? surname, int phoneNumber, string email, string? address)
        {
            CustomerID = customerID;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        public Guid CustomerID { get; set; }

        public  string? Name { get; set; }

        public  string? Surname { get; set; }

        public  int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string? Address { get; set; }
    }
}
