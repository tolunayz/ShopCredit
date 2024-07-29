using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Infrastructure.FluentApi
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        
            public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.Property(s => s.Id)
             .IsRequired();

            builder.HasKey(s => s.Id);

            builder.Property(s => s.CreatedDate)
             .IsRequired();

            builder.Property(s => s.Address)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(s => s.Name)
                 .IsRequired()   // Name özelliğini zorunlu hale getirir
                 .HasMaxLength(100);

            builder.Property(s => s.Surname)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(s => s.PhoneNumber)
               .IsRequired()
               .HasMaxLength(10);

            //builder.HasCheckConstraint("CK_PhoneNumber", "PhoneNumber NOT LIKE '0%'");

            builder.Property(s => s.Email)
               .IsRequired(false)
               .HasMaxLength(100);

            builder.Property(s => s.Address)
               .IsRequired()
               .HasMaxLength(100);

        }


    }
}
