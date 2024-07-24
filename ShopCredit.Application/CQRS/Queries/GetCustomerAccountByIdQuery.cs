namespace ShopCredit.Application.CQRS.Queries
{
    public class GetCustomerAccountByIdQuery
    {
        public int CustomerId { get; set; }

        public GetCustomerAccountByIdQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
