using MediatR;

namespace ShopCredit.Domain.Events.Common
{
    public interface IDomainEvent : INotification
    {
        bool IsPublished { get; set; }
    }


}
