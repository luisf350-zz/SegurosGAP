using Seguros.Entities.Context;
using Seguros.Entities.Entities;
using Seguros.Repositories.Repositories;
using Seguros.Services.Contract;
using System.Collections.Generic;

namespace Seguros.Services.Implementation
{
    public class PolizaService : IPolizaService
    {
        private readonly PolizaRepository _polizaRepository;

        public PolizaService()
        {
            _polizaRepository = new PolizaRepository(new ApplicationDbContext());
        }

        public IEnumerable<Poliza> GetAll()
        {
            return _polizaRepository.GetAll();
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
