using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eos.Models.CalendarEvents;
using eos.Models.Data;
using eos.Models.Subjects;
using eos.Models.Tasks;
using eos.Models.Users;

namespace eos.Models.Documents
{
    [Table("eos_documents")]
    public class Document : BaseModel
    {
        [Column("file_name")]
        [Display(Name = "File Name")]
        public String FileName { get; set; }

        [Column("extension")]
        [Display(Name = "Extension")]
        public String Extension { get; set; }

        [Column("data")]
        [Display(Name = "Data")]
        public Byte[] Data { get; set; }

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

        [ForeignKey("CalendarEvent")]
        [Column("event_id")]
        [Display(Name = "CalendarEvent")]
        public Int32? CalendarEventId { get; set; }
        public CalendarEvent CalendarEvent { get; set; }

        public static void Seed(DataContext context)
        {
            var documents = new List<Document>
            {
                new Document {
                    FileName = "test",
                    Data = new byte[] {1, 2, 3},
                    Extension = ".txt",
                    UserId = 1
                }
            };

            context.Documents.AddRange(documents);
            context.SaveChanges();
        }
    }
}