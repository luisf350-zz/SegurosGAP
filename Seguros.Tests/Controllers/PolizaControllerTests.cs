using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Seguros.Controllers;
using Seguros.Entities.Entities;
using Seguros.Services.Contract;
using System.Linq;

namespace Seguros.Tests.Controllers
{
    [TestClass]
    public class PolizaControllerTests
    {
        private Mock<IPolizaService> _polizaService;

        private Mock<ITipoCubrimientoService> _tipoCubrimientoService;

        private Mock<ITipoRiesgoService> _tipoRiesgoService;

        [TestInitialize]
        public void Setup()
        {
            _polizaService = new Mock<IPolizaService>();
            _tipoCubrimientoService = new Mock<ITipoCubrimientoService>();
            _tipoRiesgoService = new Mock<ITipoRiesgoService>();

            _polizaService.Setup(x => x.Create(It.IsAny<Poliza>())).Returns(1);
            _polizaService.Setup(x => x.Update(It.IsAny<Poliza>())).Returns(true);

            _tipoCubrimientoService.Setup(x => x.Find(1)).Returns(new TipoCubrimiento
            {
                Id = 1,
                Nombre = "Terremoto",
                Cobertura = 100
            });

            _tipoRiesgoService.Setup(x => x.Find(4)).Returns(new TipoRiesgo
            {
                Id = 4,
                Nombre = "Alto"
            });

            _tipoRiesgoService.Setup(x => x.Find(2)).Returns(new TipoRiesgo
            {
                Id = 2,
                Nombre = "Bajo"
            });
        }

        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            PolizaController controller = new PolizaController(_polizaService.Object, _tipoCubrimientoService.Object, _tipoRiesgoService.Object);
            Poliza nuevaPoliza = new Poliza
            {
                Nombre = "Prueba",
                Descripcion = "Descripcion Prueba",
                TipoCubrimientoId = 1,
                TipoRiesgoId = 4,
                MesesCobertura = 24,
                Precio = 10000000
            };

            // Act

            controller.Create(nuevaPoliza);

            // Assert
            Assert.IsFalse(controller.ModelState.IsValid);
            Assert.AreEqual(
                "No se puede seleccionar este Cubrimiento, debido a que el riesgo es Alto y la cobertura es mayor a 50%",
                controller.ModelState.Values.FirstOrDefault()?.Errors.FirstOrDefault()?.ErrorMessage);
        }

        [TestMethod]
        public void EditTest()
        {
            // Arrange
            PolizaController controller = new PolizaController(_polizaService.Object, _tipoCubrimientoService.Object, _tipoRiesgoService.Object);
            Poliza nuevaPoliza = new Poliza
            {
                Nombre = "Prueba",
                Descripcion = "Descripcion Prueba",
                TipoCubrimientoId = 1,
                TipoRiesgoId = 2,
                MesesCobertura = 24,
                Precio = 10000000
            };

            // Act

            controller.Edit(nuevaPoliza);

            // Assert
            Assert.IsTrue(controller.ModelState.IsValid);
        }
    }
}