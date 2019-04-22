using Seguros.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Seguros.Services.Contract
{
    public interface ITipoCubrimientoService
    {
        IEnumerable<TipoCubrimiento> GetAll(Expression<Func<TipoCubrimiento, bool>> filter = null, Func<IQueryable<TipoCubrimiento>, IOrderedQueryable<TipoCubrimiento>> orderBy = null, params Expression<Func<TipoCubrimiento, object>>[] includes);

        TipoCubrimiento Find(int id);

        int Create(TipoCubrimiento entity);

        bool Update(TipoCubrimiento entity);
        
        int Delete(TipoCubrimiento entity);
    }
}
