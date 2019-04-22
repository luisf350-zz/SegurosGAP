using Seguros.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Seguros.Services.Contract
{
    public interface ITipoRiesgoService
    {
        IEnumerable<TipoRiesgo> GetAll(Expression<Func<TipoRiesgo, bool>> filter = null, Func<IQueryable<TipoRiesgo>, IOrderedQueryable<TipoRiesgo>> orderBy = null, params Expression<Func<TipoRiesgo, object>>[] includes);

        TipoRiesgo Find(int id);

        int Create(TipoRiesgo entity);

        bool Update(TipoRiesgo entity);

        int Delete(TipoRiesgo entity);
    }
}
