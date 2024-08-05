using ShopCredit.Domain.Events.Common;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCredit.Domain.Entities.Base
{
    public class BaseEntity
    {
        private readonly ConcurrentQueue<DomainEvent> _domainEvents = new();
        private readonly ConcurrentQueue<IntegrationEvent> _integrationEvents = new();

        [NotMapped]
        public IProducerConsumerCollection<DomainEvent> DomainEvents => _domainEvents;
        [NotMapped]
        public IProducerConsumerCollection<IntegrationEvent> IntegrationEvents => _integrationEvents;


        protected void BaseEntityPropertys(Guid ıd, DateTime createdDate)
        {
            Id = ıd;
            CreatedDate = createdDate;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }

        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Enqueue(@domainEvent);
        }
        protected void UpdateDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Enqueue(@domainEvent);
        }

      
        //protected void UpdateDomainEvent(DomainEvent integrationEvent)
        //{
        //    _integrationEvents.Enqueue(integrationEvent);
        //}
        public BaseEntity()
        {
            
        }
        public abstract class Entity : BaseEntity
        {

        }

        
    }
}