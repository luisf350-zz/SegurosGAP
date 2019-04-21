using Seguros.Entities.Context;
using Seguros.Entities.Entities;
using Seguros.Repositories.Repositories;
using Seguros.Services.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Seguros.Services.Implementation
{
    public class TipoRiesgoService : ITipoRiesgoService
    {
        private readonly TipoRiesgoRepository _tipoRiesgoRepository;

        public TipoRiesgoService()
        {
            _tipoRiesgoRepository = new TipoRiesgoRepository(new ApplicationDbContext());
        }

        public List<TipoRiesgo> GetAll()
        {
            return _tipoRiesgoRepository.GetAll().ToList();
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
