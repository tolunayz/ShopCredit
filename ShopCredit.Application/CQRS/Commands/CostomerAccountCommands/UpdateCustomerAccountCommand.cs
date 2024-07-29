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
        public Guid AccountId { get; set; }

        public Guid CustomerId { get; set; }

        public Boolean IsPaid { get; set; }

        public  string? Description { get; set; }

        public int CurrentDebt { get; set; } //**

        public int Debt { get; set; }   //**

        public int PaidDebt { get; set; }   //**
    }

}
