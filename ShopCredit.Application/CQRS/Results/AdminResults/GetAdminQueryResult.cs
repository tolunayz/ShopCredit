namespace ShopCredit.Application.CQRS.Results.AdminResults
{
    public class GetAdminQueryResult
    {
        public Guid Id { get; set; }
        public  string? AdminName { get; set; }
        public  string? AdminPassword { get; set; }
    }
  
}
