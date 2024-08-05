using ShopCredit.Domain.Events.Common;

namespace ShopCredit.Domain.Events
{
    public class CustomerChangedEvent:IntegrationEvent
    {
        public Guid CustomerId { get; }
        
        public CustomerChangedEvent(Guid orderId)
        {
            CustomerId = orderId;
            //Type = IntegrationEventConstants.OrderConstant.OrderPlaced;
        }
    }
}
