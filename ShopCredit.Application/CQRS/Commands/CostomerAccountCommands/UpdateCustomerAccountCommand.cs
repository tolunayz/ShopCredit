using MediatR;

namespace ShopCredit.Application.CQRS.Commands.CostomerAccountCommands
{
    public class UpdateCustomerAccountCommand : IRequest
    {
        public UpdateCustomerAccountCommand(Guid accountId, bool isPaid, string description, int currentDebt, int debt, int paidDebt)
        {
            AccountId = accountId;
            IsPaid = isPaid;
            Description = description;
            CurrentDebt = currentDebt;
            Debt = debt;
            PaidDebt = paidDebt;
        }

        public Guid AccountId { get; set; }
        public bool IsPaid { get; set; }
        public string Description { get; set; }
        public int CurrentDebt { get; set; }
        public int Debt { get; set; }
        public int PaidDebt { get; set; }
    }
}
