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
    public class PolizaService : IPolizaService
    {
        private readonly PolizaRepository _polizaRepository;

        public PolizaService()
        {
            _polizaRepository = new PolizaRepository(new ApplicationDbContext());
        }

        public IEnumerable<Poliza> GetAll(Expression<Func<Poliza, bool>> filter = null, Func<IQueryable<Poliza>, IOrderedQueryable<Poliza>> orderBy = null, params Expression<Func<Poliza, object>>[] includes)
        {
            return _polizaRepository.GetAll(filter, orderBy, includes);
        }

        public Poliza Find(int id)
        {
            return _polizaRepository.GetById(id);
        }

        public int Create(Poliza entity)
        {
            return _polizaRepository.Create(entity);
        }

        public bool Update(Poliza entity)
        {
            return _polizaRepository.Update(entity);
        }

        public int Delete(Poliza entity)
        {
            return _polizaRepository.Delete(entity);
        }
    }
}
