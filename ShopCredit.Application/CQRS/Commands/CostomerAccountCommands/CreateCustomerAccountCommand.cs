namespace ShopCredit.Application.CQRS.Commands.CostomerAccountCommands
{
    public class CreateCustomerAccountCommand
    {
      
        public DateTime DebtDate { get; set; }

        public Boolean IsPaid { get; set; }

        public required string Description { get; set; }

        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required int PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

    }
}
