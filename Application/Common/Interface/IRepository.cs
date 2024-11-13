﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    // An interface that defines the basic CRUD operations
    public interface IRepository<T> where T : class
    {
        // Retrieve all records from the database
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked=true);
        // Retrieve a single record from the database
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked =true);
        // Add a new record to the database
        void Add(T entity);
        // Update an existing record in the database
        void Update(T entity);
        // Remove a record from the database
        void Remove(T entity);


    }
}
