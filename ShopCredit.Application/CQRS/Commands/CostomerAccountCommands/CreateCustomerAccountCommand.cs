﻿namespace ShopCredit.Application.CQRS.Commands.CostomerAccountCommands
{
    public class CreateCustomerAccountCommand
    {

        //public DateTime DebtDate { get; set; }

        public Guid CustomerId { get; set; }

        public bool IsPaid { get; set; }

        public  string? Description { get; set; }

        public int CurrentDebt { get; set; } //**

        public int Debt { get; set; }   //**

        public int PaidDebt { get; set; }   //**

        //public  string? Name { get; set; }

        //public  string? Surname { get; set; }

        //public  int PhoneNumber { get; set; }

        //public string? Email { get; set; }

        //public string? Address { get; set; }




        
    }
}
