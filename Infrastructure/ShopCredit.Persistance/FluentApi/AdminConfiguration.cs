using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopCredit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Infrastructure.FluentApi
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(s => s.Id)
            .IsRequired();

            builder.HasKey(s => s.Id);

            builder.Property(s => s.AdminName)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasKey(s => s.Id);

            builder.Property(s => s.AdminPassword)
                .IsRequired()
                .HasMaxLength(64);

        }
    }
}
