using System;
using System.ComponentModel.DataAnnotations;

namespace eos.Views.Subject.ViewModels
{
    public class SubjectEditViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Required]
        [Display(Name = "Details")]
        public String Details { get; set; }

        [Required]
        [Display(Name = "Color")]
        public String Color { get; set; }


    }
}