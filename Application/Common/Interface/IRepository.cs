﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked=false);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Save();
        bool Exists(T entity);

    }
}
