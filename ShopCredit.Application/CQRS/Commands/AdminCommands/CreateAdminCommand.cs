using MediatR;

namespace ShopCredit.Application.CQRS.Commands.AdminCommands
{
    public class CreateAdminCommand: IRequest<Guid>
    {
        public required string AdminName { get; set; }

        public required string AdminPassword { get; set; }
    }
}
