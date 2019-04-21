using Seguros.Entities.Context;
using Seguros.Entities.Entities;
using Seguros.Repositories.Repositories;
using Seguros.Services.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Seguros.Services.Implementation
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService()
        {
            _clienteRepository = new ClienteRepository(new ApplicationDbContext());
        }

        public List<Cliente> GetAll()
        {
            return _clienteRepository.GetAll().ToList();
        }

        public Cliente Find(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public int Create(Cliente entity)
        {
            return _clienteRepository.Create(entity);
        }

        public bool Update(Cliente entity)
        {
            return _clienteRepository.Update(entity);
        }

        public int Delete(Cliente entity)
        {
            return _clienteRepository.Delete(entity);
        }
    }
}
