using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopCredit.Application.Behaviors;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Application.CQRS.Handlers.NotificationHandlers
{
    public class CustomerUpdatedHandler : INotificationHandler<CustomerUpdatedNotification>
    {
        private readonly ILogger<CustomerUpdatedHandler> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public CustomerUpdatedHandler(ILogger<CustomerUpdatedHandler> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(CustomerUpdatedNotification notification, CancellationToken cancellationToken)
        {
            var message = $"{notification.Customer.Name} {notification.Customer.Surname} Kullanıcısının bilgileri güncellendi";

            await _publishEndpoint.Publish(new CustomerNotificationMessage
            {
                Text = $" Published : "+message
            }, cancellationToken);
        }

        public class CustomerNotificationMessage()
        {
            public string Text { get; set; }

        }
    }
}
