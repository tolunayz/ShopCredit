using System.ComponentModel.DataAnnotations;

namespace ShopCredit.Entities
{
    public class CustomerAccPayment
    {
        [Key]
        public int PaymetID { get; set; }

        public int AccountID { get; set; }

        public CustomerAccount? CustomerAccount { get; set; }

        public required string PaymetMethod { get; set; }

        public long TotalDebt { get; set; }

        public long PaidDebt { get; set; }

        public required long CurrentDebt { get; set; }
    }
}
