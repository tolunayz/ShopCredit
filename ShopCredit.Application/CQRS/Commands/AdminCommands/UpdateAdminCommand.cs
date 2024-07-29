using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.AdminCommands
{
    public class UpdateAdminCommand
    {
        public Guid AdminId { get; set; }

        public required string AdminName { get; set; }

        public required string AdminPassword { get; set; }

        
    }
}
