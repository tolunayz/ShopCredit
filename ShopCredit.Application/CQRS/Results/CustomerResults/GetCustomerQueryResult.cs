namespace ShopCredit.Application.CQRS.Results.CustomerResults
{
    public class GetCustomerQueryResult
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public List<CustomerAccountResult> CustomerAccounts { get; set; } = new List<CustomerAccountResult>();
    }

    public class CustomerAccountResult
    {
        public Guid AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
