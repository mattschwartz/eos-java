using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eos.server.Models {
    public class BaseModel {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Int32 Id {
            get;
            set;
        }

        [Column("deleted")]
        public Boolean deleted {
            get;
            set;
        }

        [Column("deleted_date_time")]
        public DateTime deletedOn {
            get;
            set;
        }

        [Column("deleted_by")]
        public User deletedBy {
            get;
            set;
        }
    }
}