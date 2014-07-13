using System.Linq;
using System.Web.Mvc;
using eos.Models.Subjects;
using eos.Views.Subject.ViewModels;
using Microsoft.AspNet.Identity;

namespace eos.Controllers
{
    [Authorize]
    public class SubjectsController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            using (var subjectManager = new SubjectManager()) {
                var subjects = subjectManager.GetAll<Subject>().Where(t => t.UserId == User.Identity.GetUserId()).ToList();

                return View(subjects);
            }
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectEditViewModel data)
        {
            using (var subjectManager = new SubjectManager()) {
                var subject = new Subject
                {
                    Title = data.Title,
                    Details = data.Details,
                    Color = data.Color
                };
                subjectManager.Save(subject);
                var subjects =
                    subjectManager.GetAll<Subject>().Where(t => t.UserId == User.Identity.GetUserId()).ToList();

                return View("Index", subjects);
            }
        }
    }
}