using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using eos.Models.Subjects;
using eos.Models.Tasks;
using eos.Views.Subjects.ViewModels;
using eos.Views.Tasks.ViewModels;
using Microsoft.AspNet.Identity;

namespace eos.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        #region Index

        #region GET: Tasks

        // GET: Tasks
        public ActionResult Index()
        {
            using (var taskManager = new TaskManager()) {
                var tasks = taskManager.GetAll<Task>().Where(t => t.UserId == User.Identity.GetUserId()).ToList();
                var results = Mapper.Map<IEnumerable<Task>, IEnumerable<TaskViewModel>>(tasks);

                var subjects = taskManager.GetAll<Subject>().Where(t => t.UserId == User.Identity.GetUserId()).ToList();
                var subjectResults = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectListBoxViewModel>>(subjects);
                ViewBag.subjects = results;

                return View(results);
            }
        }

        #endregion

        #endregion

        #region Create

        #region GET: Create

        // GET: Create
        public ActionResult Create()
        {
            using (var subjectManager = new SubjectManager()) {
                var subjects = subjectManager.GetAll<Subject>().Where(t => t.UserId == User.Identity.GetUserId()).ToList();
                var results = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectListBoxViewModel>>(subjects);
                ViewBag.subjects = results;
            }

            return View();
        }

        #endregion

        #region POST: Create

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskEditViewModel data)
        {
            using (var taskManager = new TaskManager()) {
                var task = new Task
                {
                    Title = data.Title,
                    Comment = data.Comment,
                    Color = data.Color,
                    SubjectId = data.SubjectId
                };
                taskManager.Save(task);
                var tasks = taskManager.GetAll<Task>().Where(t => t.UserId == User.Identity.GetUserId()).ToList();
                var results = Mapper.Map<IEnumerable<Task>, IEnumerable<TaskViewModel>>(tasks).ToList();
                return View("Index", results);
            }
        }

        #endregion

        #endregion
    }
}