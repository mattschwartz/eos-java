using System;
using System.ComponentModel.DataAnnotations;

namespace eos.Views.Subjects.ViewModels
{
    public class SubjectViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Required]
        [Display(Name = "Details")]
        public String Details { get; set; }

        [Required]
        [Display(Name = "# Of Tasks")]
        public Int32 TaskTotal { get; set; }
    }
}