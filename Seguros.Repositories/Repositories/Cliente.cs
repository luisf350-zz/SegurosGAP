using Seguros.Entities.Context;
using Seguros.Entities.Entities;
using Seguros.Repositories.Infraestructure;

namespace Seguros.Repositories.Repositories
{
    public interface IClienteRepository : IGenericRepository<Cliente> { }

    public class ClienteRepository : GenericRepository<Cliente>
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
