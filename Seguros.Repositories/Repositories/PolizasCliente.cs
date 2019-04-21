using Seguros.Entities.Context;
using Seguros.Entities.Entities;
using Seguros.Repositories.Infraestructure;

namespace Seguros.Repositories.Repositories
{
    public interface IPolizasClienteRepository : IGenericRepository<PolizasCliente> { }

    public class PolizasClienteRepository : GenericRepository<PolizasCliente>
    {
        public PolizasClienteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
