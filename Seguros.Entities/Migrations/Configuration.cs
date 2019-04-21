using System.Data.Entity.Migrations;
using Seguros.Entities.Entities;

namespace Seguros.Entities.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Tipo Riesgo
            context.TipoRiesgoes.AddOrUpdate(new TipoRiesgo { Id = 1, Nombre = "Bajo" });
            context.TipoRiesgoes.AddOrUpdate(new TipoRiesgo { Id = 2, Nombre = "Medio" });
            context.TipoRiesgoes.AddOrUpdate(new TipoRiesgo { Id = 3, Nombre = "Medio-Alto" });
            context.TipoRiesgoes.AddOrUpdate(new TipoRiesgo { Id = 4, Nombre = "Alto" });

            //Tipo TipoCubrimiento
            context.TipoCubrimientoes.AddOrUpdate(new TipoCubrimiento { Id = 1, Nombre = "Terremoto", Cobertura = 100 });
            context.TipoCubrimientoes.AddOrUpdate(new TipoCubrimiento { Id = 2, Nombre = "Incendio", Cobertura = 90 });
            context.TipoCubrimientoes.AddOrUpdate(new TipoCubrimiento { Id = 3, Nombre = "Robo", Cobertura = 80 });
            context.TipoCubrimientoes.AddOrUpdate(new TipoCubrimiento { Id = 4, Nombre = "Perdida", Cobertura = 70 });

            //Clientes
            context.Clientes.AddOrUpdate(new Cliente
            {
                Id = 1,
                NroDocumento = 1111111,
                Nombres = "Bill",
                Apellidos = "Gates",
                Telefono = "1-425-882-8080",
                Email = "bill.gates@microsoft.com"
            });
            context.Clientes.AddOrUpdate(new Cliente
            {
                Id = 2,
                NroDocumento = 2222222,
                Nombres = "Steve",
                Apellidos = "Jobs",
                Telefono = "1-800-692-7753",
                Email = "steve.jobs@apple.com"
            });

            base.Seed(context);
        }
    }
}
