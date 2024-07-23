using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands
{
    public class RemoveCustomerCommand
    {
        public int Id { get; set; }

        public RemoveCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
