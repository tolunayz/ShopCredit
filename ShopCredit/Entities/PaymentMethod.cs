using ShopCredit.Domain.Entities.Base;
using ShopCredit.Entities;

namespace ShopCredit.Domain.Entities
{
    public class PaymentMethod:BaseEntity
    {
        

        public required string PaymentMethodName { get; set; }

        public int PaymetID { get; set; }

        public virtual ICollection<CustomerAccPayment> CustomerAccPayments { get; set; }



    }
}
