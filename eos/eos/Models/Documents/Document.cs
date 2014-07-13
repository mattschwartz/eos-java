using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.CalendarEvents;
using eos.Models.Data;
using eos.Models.Subjects;
using eos.Models.Tasks;
using eos.Models.Users;
using Microsoft.AspNet.Identity;

namespace eos.Models.Documents
{
    [Table("eos_documents")]
    public class Document : BaseModel
    {
        public Document()
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

        [Column("file_name")]
        [Display(Name = "File Name")]
        public String FileName { get; set; }

        [Column("extension")]
        public String Extension { get; set; }

        [Column("data")]
        public Byte[] Data { get; set; }

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

        [ForeignKey("CalendarEvent")]
        [Column("event_id")]
        [Display(Name = "Calendar Event")]
        public String CalendarEventId { get; set; }
        public CalendarEvent CalendarEvent { get; set; }
    }
}