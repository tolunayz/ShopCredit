using MediatR;
using Microsoft.Extensions.Logging;
using ShopCredit.Application.Behaviors;

namespace ShopCredit.Application.CQRS.Handlers.NotificationHandlers
{
    public class CustomerCreatedEmailHandler : INotificationHandler<CustomerCreatedNotification>
    {
        private readonly ILogger<CustomerCreatedEmailHandler> _logger;
        

        public CustomerCreatedEmailHandler(ILogger<CustomerCreatedEmailHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CustomerCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation
                ($"{notification.Customer.Name} {notification.Customer.Surname} 1. Kullanıcısı için {notification.Customer.Email} Adresine mail gönderildi ");
            

            return Task.CompletedTask;
        }
    }
}
