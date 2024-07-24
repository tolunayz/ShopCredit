using Microsoft.EntityFrameworkCore;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;

namespace ShopCredit.Infrastructure.Context
{
    public class ShopCreditContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JN2JCTK;initial Catalog=ShopDebtDB;integrated Security=true;TrustServerCertificate=true");
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerAccount> CustomersAccounts { get; set; }

        public DbSet<CustomerAccPayment> CustomerAccPaymentS { get; set; }

        public DbSet<Admin> Admins { get; set; }
        
        public DbSet<PaymentMethod> PaymentMethods { get; set; }


        //Property Configurations

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(x => x.CustomerAccount)
                .WithOne(y => y.Customer)
                .HasForeignKey<CustomerAccount>(y => y.CustomerID);

            modelBuilder.Entity<CustomerAccount>()
                .HasOne(x=> x.CustomerAccPayment)
                .WithOne(y => y.CustomerAccount)
                .HasForeignKey<CustomerAccPayment>(y => y.AccountID);

        }



    }

    

    

}