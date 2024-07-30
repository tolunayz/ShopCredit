using MediatR;
using System;

namespace ShopCredit.Application.CQRS.Commands.AdminCommands
{
    public class UpdateAdminCommand : IRequest
    {
        public Guid AdminId { get; set; }
        public required string AdminName { get; set; }
        public required string AdminPassword { get; set; }
    }
}
