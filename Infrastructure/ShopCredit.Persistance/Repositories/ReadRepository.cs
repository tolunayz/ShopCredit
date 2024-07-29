using Microsoft.EntityFrameworkCore;
using ShopCredit.Application.Interfaces;
using ShopCredit.Infrastructure.Context;
using System.Linq.Expressions;

namespace ShopCredit.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly ShopCreditContext _context;

        public ReadRepository(ShopCreditContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            =>  Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            =>Table.Where(method);

         public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);

         public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}