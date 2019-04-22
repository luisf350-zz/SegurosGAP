using System.Net;
using System.Web.Mvc;
using Seguros.Entities.Entities;
using Seguros.Services.Contract;

namespace Seguros.Controllers
{
    public class PolizaController : Controller
    {
        #region Atributtes

        private readonly IPolizaService _polizaService;

        private readonly ITipoCubrimientoService _tipoCubrimientoService;

        private readonly ITipoRiesgoService _tipoRiesgoService;

        #endregion

        #region Constructor

        public PolizaController(IPolizaService polizaService, ITipoCubrimientoService tipoCubrimientoService,
            ITipoRiesgoService tipoRiesgoService)
        {
            _polizaService = polizaService;
            _tipoCubrimientoService = tipoCubrimientoService;
            _tipoRiesgoService = tipoRiesgoService;
        }

        #endregion

        #region Private Methods

        private void LoadCombos(int? tipoCubrimiento, int? tipoRiesgo)
        {
            ViewBag.TipoCubrimientoId = new SelectList(_tipoCubrimientoService.GetAll(), "Id", "NombreMostrar", tipoCubrimiento);
            ViewBag.TipoRiesgoId = new SelectList(_tipoRiesgoService.GetAll(), "Id", "Nombre", tipoRiesgo);
        }

        #endregion

        // GET: Poliza
        public ActionResult Index()
        {
            return View(_polizaService.GetAll(null, null, x => x.Cubrimiento, x => x.Riesgo));
        }

        // GET: Poliza/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = _polizaService.Find(id.Value);
            if (poliza == null)
            {
                return HttpNotFound();
            }

            LoadCombos(poliza.TipoCubrimientoId, poliza.TipoRiesgoId);

            return View(poliza);
        }

        // GET: Poliza/Create
        public ActionResult Create()
        {
            LoadCombos(null, null);
            return View();
        }

        // POST: Poliza/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,TipoCubrimientoId,TipoRiesgoId,MesesCobertura,Precio")] Poliza poliza)
        {
            TipoCubrimiento cubrimiento = _tipoCubrimientoService.Find(poliza.TipoCubrimientoId);
            TipoRiesgo riesgo = _tipoRiesgoService.Find(poliza.TipoRiesgoId);
            if (cubrimiento == null || riesgo == null)
            {
                return HttpNotFound();
            }

            if (riesgo.Nombre.Equals("Alto") && cubrimiento.Cobertura > 50)
            {
                ModelState.AddModelError("TipoCubrimientoId",
                    "No se puede seleccionar este Cubrimiento, debido a que el riesgo es Alto y la cobertura es mayor a 50%");
            }

            if (ModelState.IsValid)
            {
                _polizaService.Create(poliza);
                return RedirectToAction("Index");
            }

            LoadCombos(poliza.TipoCubrimientoId, poliza.TipoRiesgoId);
            return View(poliza);
        }

        // GET: Poliza/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = _polizaService.Find(id.Value);
            if (poliza == null)
            {
                return HttpNotFound();
            }

            LoadCombos(poliza.TipoCubrimientoId, poliza.TipoRiesgoId);

            return View(poliza);
        }

        // POST: Poliza/Edit/5
        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id,Nombre,Descripcion,TipoCubrimientoId,TipoRiesgoId,MesesCobertura,Precio")]
            Poliza poliza)
        {
            TipoCubrimiento cubrimiento = _tipoCubrimientoService.Find(poliza.TipoCubrimientoId);
            TipoRiesgo riesgo = _tipoRiesgoService.Find(poliza.TipoRiesgoId);
            if (cubrimiento == null || riesgo == null)
            {
                return HttpNotFound();
            }

            if (riesgo.Nombre.Equals("Alto") && cubrimiento.Cobertura > 50)
            {
                ModelState.AddModelError("TipoCubrimientoId",
                    "No se puede seleccionar este Cubrimiento, debido a que el riesgo es Alto y la cobertura es mayor a 50%");
            }

            if (ModelState.IsValid)
            {
                _polizaService.Update(poliza);
                return RedirectToAction("Index");
            }

            LoadCombos(poliza.TipoCubrimientoId, poliza.TipoRiesgoId);
            return View(poliza);
        }

        // GET: Poliza/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = _polizaService.Find(id.Value);
            if (poliza == null)
            {
                return HttpNotFound();
            }

            LoadCombos(poliza.TipoCubrimientoId, poliza.TipoRiesgoId);

            return View(poliza);
        }

        // POST: Poliza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Poliza poliza = _polizaService.Find(id);
            if (poliza != null)
            {
                _polizaService.Delete(poliza);
            }
            return RedirectToAction("Index");
        }


    }
}
