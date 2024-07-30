using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopCredit.Entities;

namespace ShopCredit.Infrastructure.FluentApi
{
    public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired();

            builder.Property(s => s.CreatedDate)
                .IsRequired();

            builder.Property(s => s.IsPaid)
                .IsRequired()
                .HasDefaultValue(false);// Default olarak ödenmemiş olacak.

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(666);

            builder.Property(s => s.CurrentDebt)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(c => c.Customer)
                .WithMany(ca => ca.CustomerAccounts)
                .HasForeignKey(c => c.CustomerId)
                .IsRequired();
        }
    }
}
