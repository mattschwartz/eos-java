using System;
using System.ComponentModel.DataAnnotations;

namespace eos.Views.Tasks.ViewModels
{
    public class TaskListBoxViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public String Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public String Title { get; set; }

        
    }
}