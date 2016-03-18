using System.Linq;
using System.Web.Mvc;
using Mango.BLL.Mails;
using Mango.Common.Results;
using Mango.Entities.Domain;

namespace Mango.Site.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;

        public HomeController(IMailService mailService)
        {
            _mailService = mailService;
        }

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

        [HttpPost]
        public ActionResult ContactUs(EmailItem emailItem)
        {
            if (!ModelState.IsValid) return View(emailItem);
            ServiceResult serviceResult = _mailService.SendEmail(emailItem);
            string message = !serviceResult.Succeeded ? serviceResult.Errors.FirstOrDefault() : "Successfuly sent!";
            return RedirectToAction("SentResult", new { result = message });
        }

        public ActionResult SentResult(string result)
        {
            ViewBag.Result = result;
            return View();
        }

    }
}