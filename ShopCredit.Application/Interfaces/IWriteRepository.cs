using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.Interfaces
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> CreateAsync(T entity);

        Task<bool> CreateRangeAsync(List<T> entity);

        bool Remove(T entity);
        
        bool RemoveById(string id);

        Task<bool> Update(T entity);

        Task<int> SaveAsync();
        

    }
}
