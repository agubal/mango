using System.Web.Mvc;
using Mango.BLL;
using Mango.Entities.Domain;
using Mango.Entities.Models;

namespace Mango.Site.Controllers
{
    public class MessageController : BaseMvcController<Message, MessageModel>
    {
        public MessageController(IService<Message> entityService) : base(entityService)
        {
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }       
    }
}
