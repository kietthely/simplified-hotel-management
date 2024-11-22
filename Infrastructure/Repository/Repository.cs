﻿using Application.Common.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }
        public async Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked= true)
        {
            IQueryable<T> query =dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            // if filter is not null, apply the filter i.e h => h.Id == 1
            if (filter != null)
            {
                query = query.Where(filter);
            }
            // if include properties is not null, include them i.e include(h => h.Hotel)
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

        public async Task<IEnumerable<T>>GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = true)
        {
            // Read-only operations should not be tracked. No need to modify the records.
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            // if filter is not null, apply the filter i.e h => h.Id == 1
            if (filter != null)
            {
                query = query.Where(filter);
            }
            // if include properties is not null, include them i.e include(h => h.Hotel)
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return await query.ToListAsync();
        }


        // Allow derived classes to override this method
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        // Allow derived classes to override this method
        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
        // Allow derived classes to override this method
        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public virtual bool Any(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {

            IQueryable<T> query = dbSet;

            // Apply include properties if specified
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            // Apply the filter if specified
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Check if any matching records exist
            return query.Any();
        
        }
    }
}
