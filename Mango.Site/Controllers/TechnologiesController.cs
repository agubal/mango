﻿using System.Web.Mvc;
using Mango.BLL;
using Mango.Entities.Domain;
using Mango.Entities.Models;

namespace Mango.Site.Controllers
{
    [Authorize]
    public class TechnologiesController : BaseMvcController<Technology, TechnologyModel>
    {
        public TechnologiesController(IService<Technology> entityService) : base(entityService)
        {
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
        public virtual ActionResult Create(TechnologyModel value)
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
        public virtual ActionResult Edit(int id, TechnologyModel value)
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
    }
}