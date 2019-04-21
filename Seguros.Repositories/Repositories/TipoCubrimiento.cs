using Seguros.Entities.Context;
using Seguros.Entities.Entities;
using Seguros.Repositories.Infraestructure;

namespace Seguros.Repositories.Repositories
{
    public interface ITipoCubrimientoRepository : IGenericRepository<TipoCubrimiento> { }

    public class TipoCubrimientoRepository : GenericRepository<TipoCubrimiento>
    {
        public TipoCubrimientoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
