using System;
using System.Net;
using Seguros.Services.Contract;
using System.Web.Mvc;
using Seguros.Entities.Entities;

namespace Seguros.Controllers
{
    public class PolizasClienteController : Controller
    {
        #region Atributtes

        private readonly IPolizasClienteService _polizasClienteService;

        private readonly IClienteService _clienteService;

        private readonly IPolizaService _polizaService;

        #endregion

        #region Constructor

        public PolizasClienteController(IPolizasClienteService polizasClienteService, IClienteService clienteService,
            IPolizaService polizaService)
        {
            _polizasClienteService = polizasClienteService;
            _clienteService = clienteService;
            _polizaService = polizaService;
        }

        #endregion

        #region Private Methods

        private void LoadCombos(int? cliente, int? poliza)
        {
            ViewBag.ClienteId = new SelectList(_clienteService.GetAll(), "Id", "NombreCompleto", cliente);
            ViewBag.PolizaId = new SelectList(_polizaService.GetAll(), "Id", "Nombre", poliza);
        }

        #endregion

        // GET: PolizasCliente
        public ActionResult Index()
        {
            return View(_polizasClienteService.GetAll(null, null, x => x.Cliente, x => x.Poliza));
        }

        // GET: PolizasCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolizasCliente polizasCliente = _polizasClienteService.Find(id.Value);
            if (polizasCliente == null)
            {
                return HttpNotFound();
            }

            return View(polizasCliente);
        }

        // GET: PolizasCliente/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _clienteService.Find(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            LoadCombos(cliente.Id, null);

            return View();
        }

        // POST: PolizasCliente/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,ClienteId,PolizaId,InicioCubrimiento,Activa")] PolizasCliente polizasCliente)
        {
            if (polizasCliente.InicioCubrimiento.Date < DateTime.Today)
            {
                ModelState.AddModelError("InicioCubrimiento",
                    "No se puede iniciar el cubrimiento antes del día actual.");
            }

            if (polizasCliente.InicioCubrimiento.Date.Equals(DateTime.Today) && !polizasCliente.Activa)
            {
                ModelState.AddModelError("InicioCubrimiento",
                    "La poliza debe salir activa si comienza el día actual.");
            }

            if (ModelState.IsValid)
            {
                _polizasClienteService.Create(polizasCliente);
                return RedirectToAction($"Edit/{polizasCliente.ClienteId}", "Cliente");
            }

            LoadCombos(polizasCliente.ClienteId, polizasCliente.PolizaId);
            
            return View(polizasCliente);
        }

        // GET: PolizasCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolizasCliente polizasCliente = _polizasClienteService.Find(id.Value);
            if (polizasCliente == null)
            {
                return HttpNotFound();
            }

            LoadCombos(polizasCliente.ClienteId, polizasCliente.PolizaId);

            return View(polizasCliente);
        }

        // POST: PolizasCliente/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,PolizaId,InicioCubrimiento,Activa")] PolizasCliente polizasCliente)
        {
            if (polizasCliente.InicioCubrimiento.Date < DateTime.Today)
            {
                ModelState.AddModelError("InicioCubrimiento",
                    "No se puede iniciar el cubrimiento antes del día actual.");
            }

            if (polizasCliente.InicioCubrimiento.Date.Equals(DateTime.Today) && !polizasCliente.Activa)
            {
                ModelState.AddModelError("InicioCubrimiento",
                    "La poliza debe salir activa si comienza el día actual.");
            }

            if (ModelState.IsValid)
            {
                _polizasClienteService.Update(polizasCliente);
                return RedirectToAction($"Edit/{polizasCliente.ClienteId}", "Cliente");
            }

            LoadCombos(polizasCliente.ClienteId, polizasCliente.PolizaId);

            return View(polizasCliente);
        }

        // GET: PolizasCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolizasCliente polizasCliente = _polizasClienteService.Find(id.Value);
            if (polizasCliente == null)
            {
                return HttpNotFound();
            }
            return View(polizasCliente);
        }

        // POST: PolizasCliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            PolizasCliente polizasCliente = _polizasClienteService.Find(id);
            if (polizasCliente != null)
            {
                _polizasClienteService.Delete(polizasCliente);
                return RedirectToAction($"Edit/{polizasCliente.ClienteId}", "Cliente");
            }

            return RedirectToAction("Index", "Cliente");
        }

        // GET: PolizasCliente/VolverCliente/5
        public ActionResult VolverCliente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction($"Edit/{id}", "Cliente");
        }
    }
}
