using Seguros.Entities.Context;
using Seguros.Entities.Entities;
using Seguros.Repositories.Repositories;
using Seguros.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Seguros.Services.Implementation
{
    public class PolizasClienteService : IPolizasClienteService
    {
        private readonly PolizasClienteRepository _polizasClienteRepository;

        public PolizasClienteService()
        {
            _polizasClienteRepository = new PolizasClienteRepository(new ApplicationDbContext());
        }

        public IEnumerable<PolizasCliente> GetAll(Expression<Func<PolizasCliente, bool>> filter = null, Func<IQueryable<PolizasCliente>, IOrderedQueryable<PolizasCliente>> orderBy = null, params Expression<Func<PolizasCliente, object>>[] includes)
        {
            return _polizasClienteRepository.GetAll(filter, orderBy, includes);
        }

        public PolizasCliente Find(int id)
        {
            return _polizasClienteRepository.GetById(id);
        }

        public int Create(PolizasCliente entity)
        {
            return _polizasClienteRepository.Create(entity);
        }

        public bool Update(PolizasCliente entity)
        {
            return _polizasClienteRepository.Update(entity);
        }

        public int Delete(PolizasCliente entity)
        {
            return _polizasClienteRepository.Delete(entity);
        }

        
    }
}
