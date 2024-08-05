using MediatR;
using Microsoft.Extensions.Logging;
using ShopCredit.Application.Behaviors;

namespace ShopCredit.Application.CQRS.Handlers.NotificationHandlers
{
    public class CustomerUpdatedHandler : INotificationHandler<CustomerUpdatedNotification>
    {
        private readonly ILogger<CustomerCreatedEmailHandler> _logger;

        public CustomerUpdatedHandler(ILogger<CustomerCreatedEmailHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CustomerUpdatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{notification.Customer.Name} {notification.Customer.Surname} Kullanıcısının bilgileri güncellendi");

            //  await _publishEndpoint.Publish<CustomerUpdatedNotification>(new EventModelismi()
            //{

            //   mappings
            //}
            //  );

            return Task.CompletedTask;
        }
    }
}
