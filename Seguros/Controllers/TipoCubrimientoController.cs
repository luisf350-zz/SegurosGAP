using System.Net;
using Seguros.Services.Contract;
using System.Web.Mvc;
using Seguros.Entities.Entities;

namespace Seguros.Controllers
{
    public class TipoCubrimientoController : Controller
    {
        #region Atributtes

        private readonly ITipoCubrimientoService _tipoCubrimientoService;

        #endregion

        #region Constructor
        public TipoCubrimientoController(ITipoCubrimientoService tipoCubrimientoService)
        {
            _tipoCubrimientoService = tipoCubrimientoService;
        }
        
        #endregion

        // GET: TipoCubrimiento
        public ActionResult Index()
        {
            return View(_tipoCubrimientoService.GetAll());
        }

        // GET: TipoCubrimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_tipoCubrimientoService.Find(id.Value));
        }

        // GET: TipoCubrimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCubrimiento/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Nombre,Cobertura")] TipoCubrimiento tipoCubrimiento)
        {
            if (ModelState.IsValid)
            {
                _tipoCubrimientoService.Create(tipoCubrimiento);
                return RedirectToAction("Index");
            }
            return View(tipoCubrimiento);
        }

        // GET: TipoCubrimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(_tipoCubrimientoService.Find(id.Value));
        }

        // POST: TipoCubrimiento/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Cobertura")] TipoCubrimiento tipoCubrimiento)
        {
            if (ModelState.IsValid)
            {
                _tipoCubrimientoService.Update(tipoCubrimiento);
                return RedirectToAction("Index");
            }
            return View(tipoCubrimiento);
        }

        // GET: TipoCubrimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoCubrimiento tipoCubrimiento = _tipoCubrimientoService.Find(id.Value);
            if (tipoCubrimiento == null)
            {
                return HttpNotFound();
            }

            return View(tipoCubrimiento);
        }

        // POST: TipoCubrimiento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TipoCubrimiento tipoCubrimiento = _tipoCubrimientoService.Find(id);
            if (tipoCubrimiento != null)
            {
                _tipoCubrimientoService.Delete(tipoCubrimiento);
            }
            return RedirectToAction("Index");
        }
    }
}
