using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Infrastructure.FluentApi
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {  
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired();

            builder.Property(s => s.CreatedDate)
                .IsRequired();

            builder.Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Name)
                .HasMaxLength(100); // Optional

            builder.Property(s => s.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(s => s.Email)
                .HasMaxLength(100); // Optional
          
            //builder.HasMany(c => c.CustomerAccounts)
            //  .WithOne(ca => ca.Customer)
            //  .HasForeignKey(c => c.Id)
            //  .IsRequired();
        }
    }
}
