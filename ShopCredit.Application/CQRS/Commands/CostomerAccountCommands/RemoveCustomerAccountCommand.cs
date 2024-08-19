using MediatR;

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
