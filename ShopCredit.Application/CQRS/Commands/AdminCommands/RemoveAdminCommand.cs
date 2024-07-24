using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.AdminCommands
{
    public class RemoveAdminCommand
    {
        public int Id { get; set; }

        public RemoveAdminCommand(int id)
        {
            Id = id;
        }
    }
}
