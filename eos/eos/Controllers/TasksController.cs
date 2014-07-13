using System.Web.Mvc;

namespace eos.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            return View();
        }
    }
}