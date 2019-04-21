using System.Web.Mvc;
using Seguros.Services.Contract;
using Seguros.Services.Implementation;
using Unity;
using Unity.Mvc5;

namespace Seguros
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ITipoRiesgoService, TipoRiesgoService>();
            container.RegisterType<ITipoCubrimientoService, TipoCubrimientoService>();
            container.RegisterType<IPolizaService, PolizaService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}