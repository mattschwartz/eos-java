using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.CalendarEvents;
using eos.Models.Data;
using eos.Models.Documents;
using eos.Models.Subjects;
using eos.Models.Users;
using Microsoft.AspNet.Identity;

namespace eos.Models.Tasks
{
    [Table("eos_tasks")]
    public class Task : BaseModel
    {
        public Task()
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

        [Column("color")]
        public String Color { get; set; }

        [Column("comments")]
        public String Comment { get; set; }

        [ForeignKey("Subject")]
        [Column("subject_id")]
        public String SubjectId { get; set; }

        [Column("title")]
        public String Title { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public String UserId { get; set; }
        public virtual User User { get; set; }
        
        public virtual Subject Subject { get; set; }
        public virtual List<Document> Documents { get; set; }
        public virtual List<CalendarEvent> CalendarEvents { get; set; }

        public static void Seed(DataContext context)
        {
            var tasks = new List<Task>
            {
                new Task {
                    Color = "color 2",
                    Comment = "comments 2",
                    Title = "name 2",
                    Subject = context.Subjects.First(),
                    User = context.Users.First()
                },

                new Task {
                    Color = "color 2",
                    Comment = "comments 2",
                    Title = "name 2",
                    Subject = context.Subjects.First(),
                    User = context.Users.First()
                }
            };

            context.Tasks.AddRange(tasks);
            context.SaveChanges();
        }
    }
}