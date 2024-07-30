using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.CostomerAccountCommands
{
    public class RemoveCustomerAccountCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveCustomerAccountCommand(Guid id)
        {
            Id = id;
        }
    }
}
