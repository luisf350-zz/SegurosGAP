using Seguros.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Seguros.Services.Contract
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll(Expression<Func<Cliente, bool>> filter = null, Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>> orderBy = null, params Expression<Func<Cliente, object>>[] includes);

        Cliente Find(int id);

        int Create(Cliente entity);

        bool Update(Cliente entity);

        int Delete(Cliente entity);
    }
}
