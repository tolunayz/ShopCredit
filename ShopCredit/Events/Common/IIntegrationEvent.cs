using MediatR;

namespace ShopCredit.Domain.Events.Common
{
    public interface IIntegrationEvent<out TEventType> : IIntegrationEvent
    {
        TEventType EventType { get; }
    }

    public interface IIntegrationEvent : INotification
    {
        Guid Id { get; }

        string Type { get; }
    }

    public class IntegrationEvent : IIntegrationEvent
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Type { get; init; } = default!;
    }
}

