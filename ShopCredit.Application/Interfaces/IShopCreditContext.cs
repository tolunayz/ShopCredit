using Microsoft.EntityFrameworkCore;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;

namespace ShopCredit.Application.Interfaces
{
    public interface IShopCreditContext
    {
        DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomersAccounts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
