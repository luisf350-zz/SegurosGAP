using Seguros.Entities.Entities;
using System.Collections.Generic;

namespace Seguros.Services.Contract
{
    public interface ITipoCubrimientoService
    {
        IEnumerable<TipoCubrimiento> GetAll();

        TipoCubrimiento Find(int id);

        int Create(TipoCubrimiento entity);

        bool Update(TipoCubrimiento entity);
        
        int Delete(TipoCubrimiento entity);
    }
}
