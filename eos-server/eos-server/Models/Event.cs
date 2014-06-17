using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.server.Models;

namespace eos.server.Models
{
    [Table("eos_Events")]
    public class Event : BaseModel
    {

        public String name { get; set; }

        public String description { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public String location { get; set; }
    }
}