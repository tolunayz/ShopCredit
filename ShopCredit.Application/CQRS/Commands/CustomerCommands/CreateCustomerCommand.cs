using MediatR;

namespace ShopCredit.Application.CQRS.Commands.CustomerCommands
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public  int PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
    }
}
