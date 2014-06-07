using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eos_server.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("xPos")]
        public Int32 xPos { get; set; }

        [Column("yPos")]
        public Int32 yPos { get; set; }

        [Column("name")]
        public Int32 name { get; set; }

        [Column("comments")]
        public Int32 comments { get; set; }

        [Column("color")]
        public Int32 color { get; set; }


    }
}