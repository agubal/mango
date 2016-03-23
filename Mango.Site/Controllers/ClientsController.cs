using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Mango.BLL;
using Mango.Entities.Domain;
using Mango.Entities.Models;

namespace Mango.Site.Controllers
{
    [Authorize]
    public class ClientsController : BaseMvcController<Client, ClientModel>
    {
        private readonly IService<Client> _clientService;
        public ClientsController(IService<Client> entityService) : base(entityService)
        {
            _clientService = entityService;
        }

        public ActionResult Index()
        {
            return View(GetAll());
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(Get(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(ClientModel value)
        {
            try
            {
                CreateItem(value);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(value);
            }
        }

        public virtual ActionResult Edit(int id)
        {
            return View(Get(id));
        }

        [HttpPost]
        public virtual ActionResult Edit(int id, ClientModel value)
        {
            try
            {
                EditItem(id, value);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public virtual ActionResult Delete(int id)
        {
            return View(Get(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                DeleteItem(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult MainClientsGet()
        {
            List<Client> clients = _clientService.Filter(g => g.IsMain).OrderBy(g => g.Order).ToList();
            var models = Mapper.Map<List<ClientModel>>(clients);
            return PartialView(models);
        }
    }
}
