namespace ShopCredit.Application.CQRS.Results.CustomerAccountResults
{
    public class GetAccountByIdQueryResult
    {
        public Guid AccountId { get; set; }

        public DateTime DebtDate { get; set; }

        public bool IsPaid { get; set; }

        public string? Description { get; set; }

        public int CurrentDebt { get; set; } //**

        public int Debt { get; set; }   //**

        public int PaidDebt { get; set; }   //**
    }
}
