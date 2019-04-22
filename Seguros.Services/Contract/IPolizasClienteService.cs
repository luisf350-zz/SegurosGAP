using Seguros.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Seguros.Services.Contract
{
    public interface IPolizasClienteService
    {
        IEnumerable<PolizasCliente> GetAll(Expression<Func<PolizasCliente, bool>> filter = null, Func<IQueryable<PolizasCliente>, IOrderedQueryable<PolizasCliente>> orderBy = null, params Expression<Func<PolizasCliente, object>>[] includes);

        PolizasCliente Find(int id);

        int Create(PolizasCliente entity);

        bool Update(PolizasCliente entity);

        int Delete(PolizasCliente entity);
    }
}
