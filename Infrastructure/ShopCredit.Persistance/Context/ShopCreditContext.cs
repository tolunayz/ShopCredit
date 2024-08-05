
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;
using ShopCredit.Infrastructure.FluentApi;
using System.Reflection;
using static ShopCredit.Domain.Entities.Base.BaseEntity;

namespace ShopCredit.Infrastructure.Context
{
    public class ShopCreditContext : DbContext, IShopCreditContext
    {
        private readonly IMediator _mediator;

        public ShopCreditContext(DbContextOptions<ShopCreditContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomersAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.Entity<CustomerAccount>()

            .HasOne(ca => ca.Customer)
            .WithMany(c => c.CustomerAccounts)
            .HasForeignKey(ca => ca.CustomerId);


          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JN2JCTK;initial Catalog=ShopDebtDB;integrated Security=true;TrustServerCertificate=true");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEventEntities = ChangeTracker.Entries<Entity>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents.Any())
                .ToArray();

            if (domainEventEntities.Length == 0)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            if (Database.CurrentTransaction is not null) // the transaction commit and rollback is managed outside
            {
                await PublishDomainEventsAsync(domainEventEntities, cancellationToken);
                var saveChangesResult = await base.SaveChangesAsync(cancellationToken);
                return saveChangesResult;
            }

            await PublishDomainEventsAsync(domainEventEntities, cancellationToken);
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private async Task PublishDomainEventsAsync(Entity[] domainEventEntities, CancellationToken cancellationToken)
        {
            foreach (var entity in domainEventEntities)
            {
                while (entity.DomainEvents.TryTake(out var domainEvent))
                {
                    await _mediator.Publish(domainEvent, cancellationToken);
                }
            }
        }
    }
}
