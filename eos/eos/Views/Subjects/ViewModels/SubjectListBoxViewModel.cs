using System;
using System.ComponentModel.DataAnnotations;

namespace eos.Views.Subjects.ViewModels
{
    public class SubjectListBoxViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Required]
        [Display(Name = "Id")]
        public String Id { get; set; }
    }
}