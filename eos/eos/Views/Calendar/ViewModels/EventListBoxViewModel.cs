using System;
using System.ComponentModel.DataAnnotations;

namespace eos.Views.Calendar.ViewModels
{
    public class EventListBoxViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Required]
        [Display(Name = "Id")]
        public String Id { get; set; }
    }
}