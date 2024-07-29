using System.Linq.Expressions;

namespace ShopCredit.Application.Interfaces
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);

        Task<T?> GetSingleAsync(Expression<Func<T, bool>> method);

        Task<T?> GetByIdAsync(Guid Id);
    }
}