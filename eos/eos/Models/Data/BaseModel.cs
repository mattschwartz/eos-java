using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eos.Models.Data
{
    public class BaseModel
    {
        public BaseModel()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Display(Name = "ID")]
        public Int32 Id { get; set; }

        [Column("created_on", TypeName = "DateTime2")]
        [Display(Name = "Created")]
        public DateTime CreatedOn { get; set; }

        [Column("updated_on", TypeName = "DateTime2")]
        [Display(Name = "Updated")]
        public DateTime? UpdatedOn { get; set; }
    }
}