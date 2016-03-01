using System.Web.Mvc;

namespace Mango.Site.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Careers()
        {
            return View();
        }

        public ActionResult Clients()
        {
            return View();
        }

        public ActionResult WhyTecwi()
        {
            return View();
        }

        public ActionResult Offices()
        {
            return View();
        }
    }
}