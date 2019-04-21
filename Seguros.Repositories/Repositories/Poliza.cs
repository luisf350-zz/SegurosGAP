using Seguros.Entities.Context;
using Seguros.Entities.Entities;
using Seguros.Repositories.Infraestructure;

namespace Seguros.Repositories.Repositories
{
    public interface IPolizaRepository : IGenericRepository<Poliza> { }

    public class PolizaRepository : GenericRepository<Poliza>
    {
        public PolizaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
