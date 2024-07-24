using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.Interfaces
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {

        IQueryable<T> GetAllAsync();

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);

        Task<T> GetByIdAsync(int id);
        //T GetById(string id);

        //List IEnumarabledır, işlemleri memory üzerinden yapmanı sağlar

        //Task<List<T>> GetAllAsync();

        //Task<T> GetByIdAsync(int id);



    }
}
