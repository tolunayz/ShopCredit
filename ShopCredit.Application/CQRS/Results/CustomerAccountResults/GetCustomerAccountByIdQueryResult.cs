namespace ShopCredit.Application.CQRS.Results.CustomerAccountResults
{
    public class GetCustomerAccountByIdQueryResult
    {
        public Guid AccountId { get; set; }

        public DateTime DebtDate { get; set; }

        public bool IsPaid { get; set; }

        public  string? Description { get; set; }
        
        public CustomerResult? CustomerResult { get; set; }
    }

    public class CustomerResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
  
}