namespace ShopCredit.Application.CQRS.Queries
{
    public class GetCustomerAccountByIdQuery
    {
        public Guid CustomerId { get; set; }

        public GetCustomerAccountByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
