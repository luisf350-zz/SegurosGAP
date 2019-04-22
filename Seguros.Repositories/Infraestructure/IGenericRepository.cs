using System;
using System.Linq;
using System.Linq.Expressions;

namespace Seguros.Repositories.Infraestructure
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

        T GetById(object id);

        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);

        int Create(T entity);

        bool Update(T entity);

        int Delete(T entity);
    }
}