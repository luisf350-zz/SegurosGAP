using Seguros.Entities.Entities;
using System.Data.Entity;

namespace Seguros.Entities.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(@"Data Source=EN2010065\MSSQLSERVER2017;Initial Catalog=SegurosDB;Integrated Security=True")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<TipoRiesgo> TipoRiesgoes { get; set; }

        public DbSet<TipoCubrimiento> TipoCubrimientoes { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Poliza> Polizas { get; set; }

        public DbSet<PolizasCliente> PolizasClientes { get; set; }
    }
}
