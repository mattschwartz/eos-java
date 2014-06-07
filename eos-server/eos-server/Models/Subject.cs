using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eos.server.Models {
    public class Subject : BaseModel {
        [Column("xPos")]
        public Int32 xPos {
            get;
            set;
        }

        [Column("yPos")]
        public Int32 yPos {
            get;
            set;
        }
    }
}