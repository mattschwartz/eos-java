using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eos.server.Models {

    [Table("eos_Subjects")]
    public class Subject : BaseModel {
        public Int32 xPos {
            get;
            set;
        }

        public Int32 yPos {
            get;
            set;
        }

        public User user
        {
            get;
            set;
        }
    }
}