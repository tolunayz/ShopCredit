using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopCredit.Application.Interfaces;
using ShopCredit.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Infrastructure.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
       private readonly ShopCreditContext _context;

        public WriteRepository(ShopCreditContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> CreateAsync(T entity)
        {
           EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> CreateRangeAsync(List<T> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }   
      
        public bool  Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State != EntityState.Deleted;
        }

        public bool RemoveById(string id)
        {
            _context.Set<T>().Remove(_context.Set<T>().Find(id));
            _context.SaveChanges();
            return true;
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
        
        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

       
    }
    }

