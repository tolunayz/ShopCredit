using ShopCredit.Domain.Entities;
using ShopCredit.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Entities
{
    public class CustomerAccount: BaseEntity
    {
      

        public int CustomerID { get; set; }

        public DateTime DebtDate { get; set; }

        public Boolean IsPaid { get; set; }

        public required string Description { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual CustomerAccPayment CustomerAccPayment { get; set; }
    }
}
