using Microsoft.EntityFrameworkCore;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;
using ShopCredit.Infrastructure.FluentApi;
using System.Reflection;

namespace ShopCredit.Infrastructure.Context
{
    public class ShopCreditContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JN2JCTK;initial Catalog=ShopDebtDB;integrated Security=true;TrustServerCertificate=true");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomersAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}