using System.Net;
using System.Web.Mvc;
using Seguros.Entities.Entities;
using Seguros.Services.Contract;

namespace Seguros.Controllers
{
    public class ClienteController : Controller
    {
        #region Atributttes

        private readonly IClienteService _clienteService;

        private readonly IPolizasClienteService _polizasClienteService;

        #endregion

        #region Constructor

        public ClienteController(IClienteService clienteService, IPolizasClienteService polizasClienteService)
        {
            _clienteService = clienteService;
            _polizasClienteService = polizasClienteService;
        }

        #endregion

        // GET: Cliente
        public ActionResult Index()
        {
            return View(_clienteService.GetAll());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
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
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,NroDocumento,Nombres,Apellidos,Telefono,Direccion,Email")]
            Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.Create(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
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
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,NroDocumento,Nombres,Apellidos,Telefono,Direccion,Email")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.Update(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
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
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Cliente cliente = _clienteService.Find(id);
            if (cliente != null)
            {
                _clienteService.Delete(cliente);
            }
            return RedirectToAction("Index");
        }

        // GET: Cliente/NuevaPoliza
        public ActionResult NuevaPoliza(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction($"Create/{id}", "PolizasCliente");
        }

        // GET: Cliente/EditPoliza/5
        public ActionResult EditPoliza(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolizasCliente poliza = _polizasClienteService.Find(id.Value);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction($"Edit/{id}", "PolizasCliente");
        }

        // GET: Cliente/DeletePoliza/5
        public ActionResult DeletePoliza(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolizasCliente poliza = _polizasClienteService.Find(id.Value);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction($"Delete/{id}", "PolizasCliente");
        }
    }
}
