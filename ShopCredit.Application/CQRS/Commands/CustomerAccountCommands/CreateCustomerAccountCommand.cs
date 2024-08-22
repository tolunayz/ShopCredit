using MediatR;

namespace ShopCredit.Application.CQRS.Commands.CustomerAccountCommands
{
    public class CreateCustomerAccountCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }

        public  string? Description { get; set; }

        public int Debt { get; set; }  

        public int PaidDebt { get; set; }   
  
    }
}
