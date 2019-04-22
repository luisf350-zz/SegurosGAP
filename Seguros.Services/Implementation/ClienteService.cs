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
    public class ClienteService : IClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService()
        {
            _clienteRepository = new ClienteRepository(new ApplicationDbContext());
        }

        public IEnumerable<Cliente> GetAll(Expression<Func<Cliente, bool>> filter = null, Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>> orderBy = null, params Expression<Func<Cliente, object>>[] includes)
        {
            return _clienteRepository.GetAll(filter, orderBy, includes);
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
