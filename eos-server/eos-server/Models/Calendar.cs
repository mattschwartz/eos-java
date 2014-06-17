using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.server.Models;

namespace eos.server.Models
{
    [Table("eos_Calendars")]
    public class Calendar : BaseModel
    {

        public String name { get; set; }

        public String color { get; set; }

        public User user { get; set; }

    }
}