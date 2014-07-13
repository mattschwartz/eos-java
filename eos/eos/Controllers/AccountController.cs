using System.Web.Mvc;

namespace eos.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: /Account
        public ActionResult Index()
        {
            return View();
        }
    }
}