using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using eos.Models.CalendarEvents;
using eos.Models.Documents;
using eos.Models.Subjects;

namespace eos.Views.Tasks.ViewModels
{
    public class TaskEditViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Required]
        [Display(Name = "Color")]
        public String Color { get; set; }

        [Display(Name = "Comment")]
        public String Comment { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public String SubjectId { get; set; }

        [Display(Name = "CalendarEvent")]
        public CalendarEvent CalendarEvent { get; set; }

        [Display(Name = "Documents")]
        public List<Document> Documents { get; set; }
    }
}