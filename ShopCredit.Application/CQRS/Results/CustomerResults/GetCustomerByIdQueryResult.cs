namespace ShopCredit.Application.CQRS.Results.CustomerResults
{
    public class GetCustomerByIdQueryResult
    {

        public Guid CustomerID { get; set; }

        public  string? Name { get; set; }

        public  string? Surname { get; set; }

        public  string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public List<CustomerAccountResultById> CustomerAccounts { get; set; } = new List<CustomerAccountResultById>();
    }
    public class CustomerAccountResultById
    {
        public Guid AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool  isPaid { get; set; }
        public int CurrentDebt { get; set; }

    }
}
