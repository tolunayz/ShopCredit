using MediatR;

namespace ShopCredit.Application.CQRS.Commands.CustomerAccountCommands
{
    public class PaymentCommand:IRequest
    {
        public PaymentCommand(Guid accountId, int paidDebt)
        {
            AccountId = accountId;
            PaidDebt = paidDebt;
        }
        public Guid AccountId { get; set; }
        public int PaidDebt { get; set; }
    }
}
