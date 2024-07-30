using Microsoft.EntityFrameworkCore;
using ShopCredit.Application.Interfaces;
using ShopCredit.Domain.Entities;
using ShopCredit.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Infrastructure.Repositories
{
    public class CustomerAndAccount : ICustomerAndAccountRepository
    {
        private readonly ShopCreditContext _context;

        public CustomerAndAccount(ShopCreditContext context)
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
