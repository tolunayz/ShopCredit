using ShopCredit.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ShopCredit.Entities
{
    public class CustomerAccPayment:BaseEntity
    {

        public int AccountID { get; set; }

        public int PaymetMethodId { get; set; }

        public long TotalDebt { get; set; }

        public long PaidDebt { get; set; }

        public required long CurrentDebt { get; set; }

        public virtual CustomerAccount? CustomerAccount { get; set; }

    }
}
