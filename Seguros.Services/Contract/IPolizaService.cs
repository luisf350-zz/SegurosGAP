using Seguros.Entities.Entities;
using System.Collections.Generic;

namespace Seguros.Services.Contract
{
    public interface IPolizaService
    {
        IEnumerable<Poliza> GetAll();

        Poliza Find(int id);

        int Create(Poliza entity);

        bool Update(Poliza entity);

        int Delete(Poliza entity);
    }
}
