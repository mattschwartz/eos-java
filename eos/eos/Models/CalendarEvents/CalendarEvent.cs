using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.Data;
using eos.Models.Documents;
using eos.Models.Subjects;
using eos.Models.Tasks;
using eos.Models.Users;
using Microsoft.AspNet.Identity;

namespace eos.Models.CalendarEvents
{
    [Table("eos_calendar_events")]
    public class CalendarEvent : BaseModel
    {
        public CalendarEvent()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;

            if (HttpContext.Current != null && HttpContext.Current.User != null &&
                HttpContext.Current.User.Identity != null &&
                !String.IsNullOrEmpty(HttpContext.Current.User.Identity.GetUserId())) {
                CreatedBy = HttpContext.Current.User.Identity.GetUserId();
                UserId = HttpContext.Current.User.Identity.GetUserId();
            }
        }

        [Column("title")]
        public String Title { get; set; }

        [Column("description")]
        public String Description { get; set; }

        [Column("start_date")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public String UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Subject")]
        [Column("subject_id")]
        public String SubjectId { get; set; }
        public Subject Subject { get; set; }

        [ForeignKey("Task")]
        [Column("task_id")]
        public String TaskId { get; set; }
        public Task Task { get; set; }

        public virtual List<Document> Documents { get; set; }

        public static void Seed(DataContext context)
        {
            var events = new List<CalendarEvent>
            {
                new CalendarEvent {
                    User = context.Users.First(),
                    Title = "test",
                    Description = "test",
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today,
                    Subject = context.Subjects.First(),
                    Task = context.Tasks.First()
                }
            };

            context.CalendarEvents.AddRange(events);
            context.SaveChanges();
        }
    }
}