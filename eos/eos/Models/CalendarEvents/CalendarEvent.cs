using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eos.Models.Data;
using eos.Models.Documents;
using eos.Models.Subjects;
using eos.Models.Tasks;
using eos.Models.Users;

namespace eos.Models.Events
{
    [Table("eos_events")]
    public class CalendarEvent : BaseModel
    {
        public CalendarEvent()
            : base()
        {
        }

        [Column("title")]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Column("description")]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Column("start_date", TypeName = "DateTime2")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Column("end_date", TypeName = "DateTime2")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        [Display(Name = "User")]
        public Int32 UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Subject")]
        [Column("subject_id")]
        [Display(Name = "Subject")]
        public Int32? SubjectId { get; set; }
        public Subject Subject { get; set; }

        [ForeignKey("Task")]
        [Column("task_id")]
        [Display(Name = "Task")]
        public Int32? TaskId { get; set; }
        public Task Task { get; set; }

        [Display(Name = "Documents")]
        public virtual List<Document> Documents { get; set; }

        public static void Seed(DataContext context)
        {
            var events = new List<CalendarEvent>
            {
                new CalendarEvent {
                    Title = "",
                    Description = "",
                    EndDate = DateTime.Today.AddDays(1),
                    StartDate = DateTime.Today,
                    UserId = 1
                }
            };

            context.CalendarEvents.AddRange(events);
            context.SaveChanges();
        }
    }
}