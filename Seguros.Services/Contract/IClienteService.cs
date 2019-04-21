using Seguros.Entities.Entities;
using System.Collections.Generic;

namespace Seguros.Services.Contract
{
    public interface IClienteService
    {
        List<Cliente> GetAll();

        Cliente Find(int id);

        int Create(Cliente entity);

        void Delete(Cliente entity);
    }
}
