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
    public class TipoRiesgoService : ITipoRiesgoService
    {
        private readonly TipoRiesgoRepository _tipoRiesgoRepository;

        public TipoRiesgoService()
        {
            _tipoRiesgoRepository = new TipoRiesgoRepository(new ApplicationDbContext());
        }

        public IEnumerable<TipoRiesgo> GetAll(Expression<Func<TipoRiesgo, bool>> filter = null, Func<IQueryable<TipoRiesgo>, IOrderedQueryable<TipoRiesgo>> orderBy = null, params Expression<Func<TipoRiesgo, object>>[] includes)
        {
            return _tipoRiesgoRepository.GetAll(filter, orderBy, includes);
        }

        public TipoRiesgo Find(int id)
        {
            return _tipoRiesgoRepository.GetById(id);
        }

        public int Create(TipoRiesgo entity)
        {
            return _tipoRiesgoRepository.Create(entity);
        }

        public bool Update(TipoRiesgo entity)
        {
            return _tipoRiesgoRepository.Update(entity);
        }

        public int Delete(TipoRiesgo entity)
        {
            return _tipoRiesgoRepository.Delete(entity);
        }

        
    }
}
