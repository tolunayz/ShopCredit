using ShopCredit.Domain.Events.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Domain.Events
{
    public class CustomerCreatedEvent :DomainEvent
    {
        public Guid CustomerId { get; set; }
    }
}
