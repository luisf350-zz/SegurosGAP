using Seguros.Entities.Entities;
using Seguros.Services.Contract;
using System.Net;
using System.Web.Mvc;

namespace Seguros.Controllers
{
    public class TiposRiesgoController : Controller
    {
        #region Atributtes

        private readonly ITipoRiesgoService _tipoRiesgoService;

        #endregion

        #region Constructor

        public TiposRiesgoController(ITipoRiesgoService tipoRiesgoService)
        {
            _tipoRiesgoService = tipoRiesgoService;
        }

        #endregion

        // GET: TiposRiesgo
        public ActionResult Index()
        {
            return View(_tipoRiesgoService.GetAll());
        }

        // GET: TiposRiesgo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_tipoRiesgoService.Find(id.Value));
        }

        // GET: TiposRiesgo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposRiesgo/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Nombre")] TipoRiesgo tipoRiesgo)
        {
            if (ModelState.IsValid)
            {
                _tipoRiesgoService.Create(tipoRiesgo);
                return RedirectToAction("Index");
            }
            return View(tipoRiesgo);
        }

        // GET: TiposRiesgo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(_tipoRiesgoService.Find(id.Value));
        }

        // POST: TiposRiesgo/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] TipoRiesgo tipoRiesgo)
        {
            if (ModelState.IsValid)
            {
                _tipoRiesgoService.Update(tipoRiesgo);
                return RedirectToAction("Index");
            }
            return View(tipoRiesgo);
        }

        // GET: TiposRiesgo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoRiesgo tipoRiesgo = _tipoRiesgoService.Find(id.Value);
            if (tipoRiesgo == null)
            {
                return HttpNotFound();
            }

            return View(tipoRiesgo);
        }

        // POST: TiposRiesgo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TipoRiesgo tipoRiesgo = _tipoRiesgoService.Find(id);
            if (tipoRiesgo != null)
            {
                _tipoRiesgoService.Delete(tipoRiesgo);
            }
            return RedirectToAction("Index");
        }
    }
}
