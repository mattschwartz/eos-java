using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using eos.Models.CalendarEvents;
using eos.Models.Subjects;
using eos.Models.Tasks;
using eos.Views.Calendar.ViewModels;
using eos.Views.Tasks.ViewModels;
using Microsoft.AspNet.Identity;

namespace eos.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        // GET: Calendar
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Event
        [HttpGet]
        public ActionResult Event()
        {
            using (var taskManager = new CalendarEventManager()) {
                var tasks = taskManager.GetAll<Task>().Where(t => t.UserId == User.Identity.GetUserId()).ToList();
                var taskResults = Mapper.Map<IEnumerable<Task>, IEnumerable<TaskListBoxViewModel>>(tasks);
                ViewBag.tasks = tasks;

                return View();
            }
        }

        // POST: Event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Event(EventEditViewModel data)
        {
            using (var calendarEventManager = new CalendarEventManager()) {
                var calendarEvent = new CalendarEvent
                {
                    Title = data.Title,
                    Description = data.Description,
                    StartDate = data.StartDate,
                    EndDate = data.EndDate,
                    TaskId = data.TaskId
                };
                calendarEventManager.Save(calendarEvent);

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public JsonResult EventData()
        {
            using (var calendarEventManager = new CalendarEventManager()) {
                var events = calendarEventManager.GetAll<CalendarEvent>().Where(t => t.UserId == User.Identity.GetUserId()).ToList();

                var results = from calendarEvent in events
                    select new
                    {
                        id = calendarEvent.Id,
                        title = calendarEvent.Title,
                        start = calendarEvent.StartDate,
                        end = calendarEvent.EndDate,
                        allday = true
                    };

                return Json(results.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}