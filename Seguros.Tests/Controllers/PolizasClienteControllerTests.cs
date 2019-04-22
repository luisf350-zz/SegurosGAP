using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Seguros.Controllers;
using Seguros.Entities.Entities;
using Seguros.Services.Contract;

namespace Seguros.Tests.Controllers
{
    [TestClass]
    public class PolizasClienteControllerTests
    {
        private Mock<IPolizaService> _polizaService;

        private Mock<IPolizasClienteService> _polizasClienteService;

        private Mock<IClienteService> _clienteService;

        [TestInitialize]
        public void Setup()
        {
            _polizaService = new Mock<IPolizaService>();
            _polizasClienteService = new Mock<IPolizasClienteService>();
            _clienteService = new Mock<IClienteService>();

            _polizasClienteService.Setup(x => x.Create(It.IsAny<PolizasCliente>())).Returns(1);

            _clienteService.Setup(x => x.Find(1)).Returns(new Cliente
            {
                Id = 1,
                NroDocumento = 1111111,
                Nombres = "Bill",
                Apellidos = "Gates",
                Telefono = "1-425-882-8080",
                Email = "bill.gates@microsoft.com"
            });

            _polizaService.Setup(x => x.Find(1)).Returns(new Poliza
            {
                Id = 1,
                Nombre = "Cumplimiento",
                Descripcion = "Poliza de cumplimiento",
                TipoRiesgoId = 3,
                TipoCubrimientoId = 1,
                MesesCobertura = 22,
                Precio = 10000000
            });

        }

        [TestMethod]
        public void CreateDayBeforeTest()
        {
            // Arrange
            PolizasClienteController controller = new PolizasClienteController(_polizasClienteService.Object, _clienteService.Object, _polizaService.Object);
            PolizasCliente nuevaPoliza = new PolizasCliente()
            {
                ClienteId = 1,
                PolizaId = 1,
                InicioCubrimiento = DateTime.Now.AddDays(-10),
                Activa = true
            };

            // Act

            controller.Create(nuevaPoliza);

            // Assert
            Assert.IsFalse(controller.ModelState.IsValid);
            Assert.AreEqual(
                "No se puede iniciar el cubrimiento antes del día actual.",
                controller.ModelState.Values.FirstOrDefault()?.Errors.FirstOrDefault()?.ErrorMessage);
        }

        [TestMethod]
        public void CreateTodayActiveTest()
        {
            // Arrange
            PolizasClienteController controller = new PolizasClienteController(_polizasClienteService.Object, _clienteService.Object, _polizaService.Object);
            PolizasCliente nuevaPoliza = new PolizasCliente()
            {
                ClienteId = 1,
                PolizaId = 1,
                InicioCubrimiento = DateTime.Today,
                Activa = false
            };

            // Act

            controller.Create(nuevaPoliza);

            // Assert
            Assert.IsFalse(controller.ModelState.IsValid);
            Assert.AreEqual(
                "La poliza debe salir activa si comienza el día actual.",
                controller.ModelState.Values.FirstOrDefault()?.Errors.FirstOrDefault()?.ErrorMessage);
        }
    }
}