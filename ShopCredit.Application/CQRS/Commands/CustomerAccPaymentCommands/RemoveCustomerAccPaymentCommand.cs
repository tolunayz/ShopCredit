using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.CustomerAccPaymentCommands
{
    public class RemoveCustomerAccPaymentCommand
    {
        public int Id { get; set; }

        public RemoveCustomerAccPaymentCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
