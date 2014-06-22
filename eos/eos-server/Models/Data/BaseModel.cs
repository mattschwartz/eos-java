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
            this.deleted = false;
            this.createdOn = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Display(Name = "ID")]
        public Int32 id { get; set; }
        
        [Column("deleted")]
        [Display(Name = "Deleted")]
        public Boolean deleted { get; set; }

        [Column("deleted_by")]
        [Display(Name = "Deleted By")]
        public User deletedBy { get; set; }

        [Column("deleted_date_time", TypeName = "DateTime2")]
        [Display(Name = "Deleted On")]
        public DateTime deletedOn { get; set; }

        [Column("created_by")]
        [Display(Name = "Created By")]
        public User createdBy { get; set; }

        [Column("created_date_time", TypeName = "DateTime2")]
        [Display(Name = "Created On")]
        public DateTime createdOn { get; set; }
    }
}