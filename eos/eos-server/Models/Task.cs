using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.Data;

namespace eos.Models
{
    [Table("eos_tasks")]
    public class Task : BaseModel
    {
        [Column("name")]
        [Display(Name = "Name")]
        public String name { get; set; }

        [Column("comments")]
        [Display(Name = "Comments")]
        public String comments { get; set; }

        [Column("color")]
        [Display(Name = "Color")]
        public String color { get; set; }

        [Column("user")]
        [Display(Name = "User")]
        public Int32 UserId { get; set; }
        public virtual User user { get; set; }
    }
}