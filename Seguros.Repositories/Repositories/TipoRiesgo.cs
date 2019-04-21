using Seguros.Entities.Context;
using Seguros.Entities.Entities;
using Seguros.Repositories.Infraestructure;

namespace Seguros.Repositories.Repositories
{
    public interface ITipoRiesgoRepository: IGenericRepository<TipoRiesgo> { }

    public class TipoRiesgoRepository : GenericRepository<TipoRiesgo>
    {
        public TipoRiesgoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
