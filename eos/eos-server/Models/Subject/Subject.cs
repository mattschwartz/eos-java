using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.Data;

namespace eos.Models
{
    [Table("eos_Subjects")]
    public class Subject : BaseModel
    {
        [Column("x_pos")]
        [Display(Name = "X Pos")]
        public Int32 xPos { get; set; }

        [Column("y_pos")]
        [Display(Name = "Y Pos")]
        public Int32 yPos { get; set; }

        [Column("user_id")]
        [Display(Name = "User")]
        public Int32 UserId { get; set; }
        public virtual User user { get; set; }
    }
}