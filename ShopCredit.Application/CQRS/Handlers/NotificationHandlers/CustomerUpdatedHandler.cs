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
            //_logger.LogInformation(message);
            _logger.LogInformation($"Gönderilen Mesaj:{message}");

            //var customerUpdatedEvent = new CustomerUpdateEvent
            //{
            //    Name = notification.Customer.Name,
            //    Surname = notification.Customer.Surname,
            //    Email = notification.Customer.Email
            //};

            //await _publishEndpoint.Publish(customerUpdatedEvent, cancellationToken);

            await _publishEndpoint.Publish(new CustomerNotificationMessage
            {
                Text = $"Giden published"+message
            }, cancellationToken);

        }

        public class CustomerNotificationMessage()
        {
            public string Text { get; set; }

        }
    }
}
