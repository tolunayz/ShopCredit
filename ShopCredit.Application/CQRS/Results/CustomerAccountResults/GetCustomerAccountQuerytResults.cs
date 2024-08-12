namespace ShopCredit.Application.CQRS.Results.CustomerAccountResults
{
    public class GetCustomerAccountQuerytResults
    {
        public Guid AccountId { get; set; }

        public int CustomerId { get; set; }

        public CustomerResults? Customer { get; set; }

        public DateTime DebtDate { get; set; }

        public Boolean IsPaid { get; set; }

        public string Description { get; set; }


    }
    public class CustomerResults
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }



    }
}
