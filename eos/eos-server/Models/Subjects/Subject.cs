using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.Data;
using eos.Models.Tasks;
using eos.Models.Users;

namespace eos.Models.Subjects
{
    [Table("eos_subjects")]
    public class Subject : BaseModel
    {
        [Column("xpos")]
        [Display(Name = "X Pos")]
        public Int32 XPos { get; set; }

        [Column("ypos")]
        [Display(Name = "Y Pos")]
        public Int32 YPos { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        [Display(Name = "User")]
        public Int32? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
}