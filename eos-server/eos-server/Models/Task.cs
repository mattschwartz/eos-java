using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eos.server.Models {

    [Table("eos_Tasks")]
    public class Task : BaseModel {

        public String name {
            get;
            set;
        }

        public String comments {
            get;
            set;
        }

        public String color {
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