using MediatR;

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
