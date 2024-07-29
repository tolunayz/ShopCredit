﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.CustomerCommands
{
    public class UpdateCustomerCommand
    {
        public Guid CustomerID { get; set; }

        public  string? Name { get; set; }

        public  string? Surname { get; set; }

        public  int PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
