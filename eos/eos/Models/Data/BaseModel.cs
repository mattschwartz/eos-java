using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.Users;

namespace eos.Models.Data
{
    public class BaseModel
    {
        public BaseModel()
        {
            //this.Deleted = false;
            //this.CreatedOn = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Display(Name = "ID")]
        public Int32 Id { get; set; }
        
        //[Column("deleted")]
        //[Display(Name = "Deleted")]
        //public Boolean Deleted { get; set; }

        //[Column("deleted_by")]
        //[Display(Name = "Deleted By")]
        //public Int32? DeletedByUserId { get; set; }
        //public User DeletedBy { get; set; }

        //[Column("deleted_date_time", TypeName = "DateTime2")]
        //[Display(Name = "Deleted On")]
        //public DateTime? DeletedOn { get; set; }

        //[Column("created_by")]
        //[Display(Name = "Created By")]
        //public Int32? CreatedByuserId { get; set; }
        //public User CreatedBy { get; set; }

        //[Column("created_date_time", TypeName = "DateTime2")]
        //[Display(Name = "Created On")]
        //public DateTime? CreatedOn { get; set; }
    }
}