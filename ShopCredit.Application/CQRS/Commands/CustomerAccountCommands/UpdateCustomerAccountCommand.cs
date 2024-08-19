using MediatR;

namespace ShopCredit.Application.CQRS.Commands.CostomerAccountCommands
{
    public class UpdateCustomerAccountCommand : IRequest
    {
        public UpdateCustomerAccountCommand(Guid accountId, string description, int debt, int paidDebt)
        {
            AccountId = accountId;        
            Description = description;        
            Debt = debt;
            PaidDebt = paidDebt;
        }

        public Guid AccountId { get; set; }
        public string Description { get; set; }
        public int Debt { get; set; }
        public int PaidDebt { get; set; }
    }
}
