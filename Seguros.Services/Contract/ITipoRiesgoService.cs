using Seguros.Entities.Entities;
using System.Collections.Generic;

namespace Seguros.Services.Contract
{
    public interface ITipoRiesgoService
    {
        List<TipoRiesgo> GetAll();

        TipoRiesgo Find(int id);

        int Create(TipoRiesgo entity);

        void Delete(TipoRiesgo entity);
    }
}
