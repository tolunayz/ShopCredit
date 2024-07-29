using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.AdminCommands
{
    public class RemoveAdminCommand
    {
        public Guid Id { get; set; }

        public RemoveAdminCommand(Guid id)
        {
            Id = id;
        }
    }
}
