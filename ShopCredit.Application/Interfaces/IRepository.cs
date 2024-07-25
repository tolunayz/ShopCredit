﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCredit.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }

        //bool RemoveById(string id);

        ////Task<List<T>> GetAllAsync();

        ////Task<T> GetByIdAsync(int id);

        ////Task CreateAsync(T entity);

        ////Task UpdateAsync(T entity);

        ////Task RemoveAsync(T entity);
    }
}
