using Seguros.Entities.Context;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace Seguros.Repositories.Infraestructure
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        private readonly IDbSet<T> _dbSet;

        private bool _disposed;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public int Create(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _dbSet.AddOrUpdate(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }
       
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
