using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.Data;
using eos.Models.Tasks;
using eos.Models.Users;

namespace eos.Models.Subjects
{
    [Table("eos_subjects")]
    public class Subject : BaseModel
    {
        public Subject() 
            : base()
        {

        }

        [Column("color")]
        [Display(Name = "Color")]
        public String Color { get; set; }

        [Column("details")]
        [Display(Name = "Details")]
        public String Details { get; set; }

        [Column("radius")]
        [Display(Name = "Radius")]
        public Decimal Radius { get; set; }
        
        [Column("title")]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        [Display(Name = "User")]
        public Int32? UserId { get; set; }
        public virtual User User { get; set; }

        [Column("xpos")]
        [Display(Name = "X Pos")]
        public Int32 XPos { get; set; }

        [Column("ypos")]
        [Display(Name = "Y Pos")]
        public Int32 YPos { get; set; }

        [Display(Name = "Tasks")]
        public virtual List<Task> Tasks { get; set; }

        public static void Seed(DataContext context)
        {
            var Subjects = new List<Subject>
            {
                new Subject {
                    User = context.Users.First(),
                    XPos = 1,
                    YPos = 1,
                    Color = "color",
                    Details = "details",
                    Radius = Decimal.One, 
                    Title = "",
                },

                new Subject {
                    User = context.Users.First(),
                    XPos = 1,
                    YPos = 1,
                    Color = "color",
                    Details = "details",
                    Radius = Decimal.One, 
                    Title = "",
                }
            };

            context.Subjects.AddRange(Subjects);
            context.SaveChanges();
        }
    }
}