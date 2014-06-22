using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.Data;

namespace eos.Models
{
    [Table("eos_Users")]
    public class User : BaseModel
    {
        [Column("first_name")]
        [Display(Name = "First Name")]
        public String firstName { get; set; }

        [Column("last_name")]
        [Display(Name = "Last Name")]
        public String lastName { get; set; }

        [Column("email")]
        [Display(Name = "Email")]
        public String email { get; set; }

        [Column("password")]
        [Display(Name = "Password")]
        public String password { get; set; }

        // why does user have a user on it
        [Column("user_id")]
        [Display(Name = "User")]
        public Int32 UserId { get; set; }
        public virtual User user { get; set; }
    }
}