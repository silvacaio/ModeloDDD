using AutoMapper;
using ModeloDDD.Application.Interfaces;
using ModeloDDD.Domain.Entities;
using ModeloDDD.MVC.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteAppService.GetAll());
            return View(clienteViewModel);
        }

        public ActionResult Especiais()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteAppService.ObterClientesEspeciais());
            return View(clienteViewModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(_clienteAppService.GetById(id));
            return View(clienteViewModel);
        }

        // GET: Clientes/Create        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                    _clienteAppService.Add(clienteDomain);
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(_clienteAppService.GetById(id));
            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                    _clienteAppService.Update(clienteDomain);
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(_clienteAppService.GetById(id));
            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var cliente = _clienteAppService.GetById(id);
                _clienteAppService.Remove(cliente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
