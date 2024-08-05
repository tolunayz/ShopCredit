using ShopCredit.Domain.Events.Common;

namespace ShopCredit.Domain.Events
{
    public class CustomerCreatedEvent :DomainEvent
    {
        public Guid CustomerId { get; set; }
    }
}
