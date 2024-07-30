using MediatR;

namespace ShopCredit.Application.CQRS.Commands.AdminCommands
{
    public class RemoveAdminCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveAdminCommand(Guid id)
        {
            Id = id;
        }
    }
}
