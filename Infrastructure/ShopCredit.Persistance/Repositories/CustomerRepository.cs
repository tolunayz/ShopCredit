using Microsoft.EntityFrameworkCore;
using ShopCredit.Application.Interfaces;
using ShopCredit.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Infrastructure.Repositories
{
    public class CustomerRepository<Customer> : IRepository<Customer> where Customer : class
    {
        private readonly ShopCreditContext _context;

        public CustomerRepository(ShopCreditContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(Customer entity)
        {
            _context.Set<Customer>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}

//public async Task CreateAsync(T entity)
//{
//    _context.Set<T>().Add(entity);
//    await _context.SaveChangesAsync();
//}

//public async Task<List<T>> GetAllAsync()
//{
//    return await _context.Set<T>().ToListAsync();
//}

//public async Task<T> GetByIdAsync(int id)
//{
//    return await _context.Set<T>().FindAsync(id);
//}

//public async Task RemoveAsync(T entity)
//{
//    _context.Set<T>().Remove(entity);
//    await _context.SaveChangesAsync();
//}

//public async Task UpdateAsync(T entity)
//{
//    _context.Set<T>().Update(entity);
//    await _context.SaveChangesAsync();
//}