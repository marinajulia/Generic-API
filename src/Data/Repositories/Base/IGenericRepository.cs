﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.UowRepository.Data.Repositories.Base
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);

        Task<T> GetByIdAsync(int id);
        //esse abaixo é mais flexível, serve para ser passada uma expressão dentro dele
        Task<T> FirstAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> GetDataAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int? skip = null,
            int? take = null);
    }
}
