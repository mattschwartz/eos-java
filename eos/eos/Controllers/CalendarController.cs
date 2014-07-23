using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Script.Serialization;
using AutoMapper;
using eos.Models.CalendarEvents;
using eos.Models.Data;
using eos.Models.Tasks;
using eos.Views.Calendar.ViewModels;
using eos.Views.Tasks.ViewModels;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace eos.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        // GET: Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region Event

        #region GET: Event

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

        #endregion

        #region POST: Event

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

        #endregion

        #region GET: EventData

        // GET: EventData
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
                        allday = true,
                        color = calendarEvent.Color
                    };

                return Json(results.ToArray(), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #endregion

        // POST: Update
        [HttpPost]
        public ActionResult Update(String id, String startDate, String endDate)
        {
            using (var context = new DataContext()) {
                var calendarEvent = context.CalendarEvents.Find(id);
                calendarEvent.StartDate = DateTime.Parse(startDate);
                calendarEvent.EndDate = DateTime.Parse(endDate);
                context.SaveChanges();
            }

            return View("Index");
        }
    }
}