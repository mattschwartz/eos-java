using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.Data;
using eos.Models.Users;

namespace eos.Models.Tasks
{
    [Table("eos_tasks")]
    public class Task : BaseModel
    {
        [Column("name")]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Column("comments")]
        [Display(Name = "Comments")]
        public String Comments { get; set; }

        [Column("color")]
        [Display(Name = "Color")]
        public String Color { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        [Display(Name = "User")]
        public Int32? UserId { get; set; }
        public virtual User User { get; set; }
    }
}