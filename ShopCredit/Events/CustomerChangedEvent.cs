using ShopCredit.Domain.Events.Common;

namespace ShopCredit.Domain.Events
{
    public class CustomerChangedEvent:DomainEvent
    {
        public Guid CustomerId { get; set; }

    
    }
}
