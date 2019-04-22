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
    public class TipoCubrimientoService : ITipoCubrimientoService
    {
        private readonly TipoCubrimientoRepository _tipoCubrimientoRepository;

        public TipoCubrimientoService()
        {
            _tipoCubrimientoRepository = new TipoCubrimientoRepository(new ApplicationDbContext());
        }

        public IEnumerable<TipoCubrimiento> GetAll(Expression<Func<TipoCubrimiento, bool>> filter = null, Func<IQueryable<TipoCubrimiento>, IOrderedQueryable<TipoCubrimiento>> orderBy = null, params Expression<Func<TipoCubrimiento, object>>[] includes)
        {
            return _tipoCubrimientoRepository.GetAll(filter, orderBy, includes);
        }

        public TipoCubrimiento Find(int id)
        {
            return _tipoCubrimientoRepository.GetById(id);
        }

        public int Create(TipoCubrimiento entity)
        {
            return _tipoCubrimientoRepository.Create(entity);
        }

        public bool Update(TipoCubrimiento entity)
        {
            return _tipoCubrimientoRepository.Update(entity);
        }

        public int Delete(TipoCubrimiento entity)
        {
            return _tipoCubrimientoRepository.Delete(entity);
        }
    }
}
