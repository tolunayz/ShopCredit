using ShopCredit.Application.CQRS.Results.CustomerResults;

namespace ShopCredit.Application.CQRS.Results.CustomerAccountResults
{
    public class GetCustomerAccountByIdQueryResult
    {
        public Guid AccountId { get; set; }

        public DateTime DebtDate { get; set; }

        public Boolean IsPaid { get; set; }

        public required string Description { get; set; }
        
        public GetCustomerQueryResult? CustomerResult { get; set; }
    
        
    }
}