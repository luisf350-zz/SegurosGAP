using Seguros.Entities.Entities;
using System.Collections.Generic;

namespace Seguros.Services.Contract
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll();

        Cliente Find(int id);

        int Create(Cliente entity);

        bool Update(Cliente entity);

        int Delete(Cliente entity);
    }
}
