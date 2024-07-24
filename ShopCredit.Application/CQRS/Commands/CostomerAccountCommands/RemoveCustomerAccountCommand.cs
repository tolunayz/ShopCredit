using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.CostomerAccountCommands
{
    public class RemoveCustomerAccountCommand
    {
        public int Id { get; set; }

        public RemoveCustomerAccountCommand(int id)
        {
            Id = id;
        }
    }
}
