using Seguros.Entities.Entities;
using System.Collections.Generic;

namespace Seguros.Services.Contract
{
    public interface IPolizaService
    {
        List<Poliza> GetAll();

        Poliza Find(int id);

        int Create(Poliza entity);

        void Delete(Poliza entity);
    }
}
