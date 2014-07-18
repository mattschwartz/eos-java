using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eos.Models.Subjects;
using eos.Models.Tasks;
using eos.Models.Users;

namespace eos.Views.Calendar.ViewModels
{
    public class EventEditViewModel
    {
        [Required]
        public String Title { get; set; }

        public String Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public String TaskId { get; set; }
    }
}