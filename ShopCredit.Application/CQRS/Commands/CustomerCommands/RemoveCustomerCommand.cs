using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.CQRS.Commands.CustomerCommands
{
    public class RemoveCustomerCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveCustomerCommand(Guid id)
        {
            Id = id;
        }
    }
}
