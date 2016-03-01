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
    public class ServicesController : BaseMvcController<Service, ServiceModel>
    {
        private readonly IService<Service> _servicesService;
        public ServicesController(IService<Service> serviceService) : base(serviceService)
        {
            _servicesService = serviceService;
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
        public virtual ActionResult Create(ServiceModel value)
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
        public virtual ActionResult Edit(int id, ServiceModel value)
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

        public ActionResult MainServicesGet()
        {
            List<Service> services = _servicesService.Filter(g => g.IsMain).OrderBy(g => g.Order).ToList();
            var models = Mapper.Map<List<ServiceModel>>(services);
            return PartialView(models);
        }

        public ActionResult YourDevelopmentTeam()
        {
            return View();
        }

        public ActionResult ApplicationsDevelopment()
        {
            return View();
        }

        public ActionResult SoftwareQualityAssurance()
        {
            return View();
        }
    }
}
