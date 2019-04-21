using Seguros.Entities.Context;
using Seguros.Entities.Entities;
using Seguros.Repositories.Repositories;
using Seguros.Services.Contract;
using System.Collections.Generic;

namespace Seguros.Services.Implementation
{
    public class PolizasClienteService : IPolizasClienteService
    {
        private readonly PolizasClienteRepository _polizasClienteRepository;

        public PolizasClienteService()
        {
            _polizasClienteRepository = new PolizasClienteRepository(new ApplicationDbContext());
        }

        public IEnumerable<PolizasCliente> GetAll()
        {
            return _polizasClienteRepository.GetAll();
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
