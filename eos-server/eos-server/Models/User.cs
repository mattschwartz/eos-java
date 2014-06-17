using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eos.server.Models {

    [Table("eos_Users")]
    public class User : BaseModel {
        public String firstName
        {
            get;
            set;
        }

        public String lastName
        {
            get;
            set;
        }

        public String email
        {
            get;
            set;
        }

        public String password
        {
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