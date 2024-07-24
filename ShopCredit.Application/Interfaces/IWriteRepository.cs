using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.Interfaces
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);

        Task<bool> AddAsync(List<T> entity);

        Task<bool> Remove(T entity);

        Task<bool> Remove(int id);

        Task<bool> UpdateAsync(T entity);

        

    }
}
