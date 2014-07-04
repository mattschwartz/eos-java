using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using eos.Models.Data;
using eos.Models.Documents;
using eos.Models.Events;
using eos.Models.Subjects;
using eos.Models.Users;

namespace eos.Models.Tasks
{
    [Table("eos_tasks")]
    public class Task : BaseModel
    {
        public Task() 
            : base()
        {
        }

        [Column("color")]
        [Display(Name = "Color")]
        public String Color { get; set; }

        [Column("comments")]
        [Display(Name = "Comments")]
        public String Comments { get; set; }

        [ForeignKey("Subject")]
        [Column("subject_id")]
        [Display(Name = "Subject")]
        public Int32 SubjectId { get; set; }

        [Column("title")]
        [Display(Name = "Title")]
        public String Name { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        [Display(Name = "User")]
        public Int32? UserId { get; set; }
        public virtual User User { get; set; }

        [Display(Name = "Subject")]
        public virtual Subject Subject { get; set; }

        [Display(Name = "Documents")]
        public virtual List<Document> Documents { get; set; }

        [Display(Name = "Calendar Events")]
        public virtual List<CalendarEvent> CalendarEvents { get; set; }

        public static void Seed(DataContext context)
        {
            var tasks = new List<Task>
            {
                new Task {
                    Color = "color 2",
                    Comments = "comments 2",
                    Name = "name 2",
                    Subject = context.Subjects.First(),
                    User = context.Users.First()
                },

                new Task {
                    Color = "color 2",
                    Comments = "comments 2",
                    Name = "name 2",
                    Subject = context.Subjects.First(),
                    User = context.Users.First()
                }
            };

            context.Tasks.AddRange(tasks);
            context.SaveChanges();
        }
    }
}