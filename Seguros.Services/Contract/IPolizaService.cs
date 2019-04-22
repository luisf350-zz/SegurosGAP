using Seguros.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Seguros.Services.Contract
{
    public interface IPolizaService
    {
        IEnumerable<Poliza> GetAll(Expression<Func<Poliza, bool>> filter = null, Func<IQueryable<Poliza>, IOrderedQueryable<Poliza>> orderBy = null, params Expression<Func<Poliza, object>>[] includes);

        Poliza Find(int id);

        int Create(Poliza entity);

        bool Update(Poliza entity);

        int Delete(Poliza entity);
    }
}
