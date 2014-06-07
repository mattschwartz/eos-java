using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eos.server.Models {
    public class Task : BaseModel {

        [Column("name")]
        public Int32 name {
            get;
            set;
        }

        [Column("comments")]
        public Int32 comments {
            get;
            set;
        }

        [Column("color")]
        public Int32 color {
            get;
            set;
        }
    }
}