using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Domain.Entities
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }

        public required string PaymentMethodName { get; set; }

        public int PaymetID { get; set; }

        public virtual ICollection<CustomerAccPayment> CustomerAccPayments { get; set; }



    }
}
