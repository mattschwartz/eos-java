using System;
using System.ComponentModel.DataAnnotations;

namespace eos.Views.Calendar.ViewModels
{
    public class EventEditViewModel
    {
        public String Id { get; set; }

        [Required]
        public String Title { get; set; }

        public String Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public String TaskId { get; set; }
    }
}