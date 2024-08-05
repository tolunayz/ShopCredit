namespace ShopCredit.Domain.Events.Common
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsPublished { get; set; }

    }
}
