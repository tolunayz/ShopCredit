using MassTransit;
using static ShopCredit.Application.CQRS.Handlers.NotificationHandlers.CustomerUpdatedHandler;

namespace ShopCredit.Application.CQRS.EventHandlers
{
    public class ConsumeHandler : IConsumer<CustomerNotificationMessage>
    {
        public Task Consume(ConsumeContext<CustomerNotificationMessage> context)
        {
            var message = context.Message.Text;
            Console.WriteLine(message);

            return Task.CompletedTask;
        }
    }
}
