using Microsoft.EntityFrameworkCore;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;

namespace ShopCredit.Infrastructure.Repositories
{
    public class CustomerAndAccount : ICustomerAndAccountRepository
    {
        private readonly IShopCreditContext _context;

        public CustomerAndAccount(IShopCreditContext context)
        {
            _context = context;
        }

      
        //public IEnumerable<Customer> GetCustomers()
        //{
        //    return _context.Customers
        //                   .Include(c => c.CustomerAccounts)
        //                   .ToList();

        //}

        public async Task<Customer?> GetCustomerByIdWithAccountsAsync(Guid customerId)
        {
            return await _context.Customers
                   .Include(c => c.CustomerAccounts)
                   .FirstOrDefaultAsync(c => c.Id == customerId);
        }
    }
}
