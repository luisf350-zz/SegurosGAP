using Seguros.Entities.Entities;
using System.Collections.Generic;

namespace Seguros.Services.Contract
{
    public interface ITipoCubrimientoService
    {
        List<TipoCubrimiento> GetAll();

        TipoCubrimiento Find(int id);

        int Create(TipoCubrimiento entity);

        void Delete(TipoCubrimiento entity);
    }
}
