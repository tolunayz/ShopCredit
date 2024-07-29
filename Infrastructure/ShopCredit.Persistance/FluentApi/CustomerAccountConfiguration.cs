using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Infrastructure.FluentApi
{
    public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.Property(s => s.Id)
             .IsRequired();

            builder.HasKey(s => s.Id);

            builder.Property(s => s.CreatedDate)
             .IsRequired();

            builder.Property(s => s.IsPaid)
           .IsRequired()
           .HasDefaultValue(false);// Default olarak ödenmemiş olacak.

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(s => s.CurrentDebt)
                .IsRequired()
                .HasMaxLength(100);

        }


    }
}
