using System.Web.Mvc;

namespace eos.Controllers
{
    [Authorize]
    public class VerseController : Controller
    {
        // GET: Verse
        public ActionResult Index()
        {
            return View();
        }
    }
}