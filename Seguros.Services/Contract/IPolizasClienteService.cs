using Seguros.Entities.Entities;
using System.Collections.Generic;

namespace Seguros.Services.Contract
{
    public interface IPolizasClienteService
    {
        List<PolizasCliente> GetAll();

        PolizasCliente Find(int id);

        int Create(PolizasCliente entity);

        void Delete(PolizasCliente entity);
    }
}
