using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using eos.Models.CalendarEvents;
using eos.Models.Data;
using eos.Models.Documents;
using eos.Models.Tasks;
using eos.Models.Users;

namespace eos.Models.Subjects
{
    [Table("eos_subjects")]
    public class Subject : BaseModel
    {
        [Column("color")]
        public String Color { get; set; }

        [Column("details")]
        public String Details { get; set; }

        [Column("radius")]
        public Decimal Radius { get; set; }
        
        [Column("title")]
        public String Title { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public String UserId { get; set; }
        public virtual User User { get; set; }

        [Column("xpos")]
        [Display(Name = "X Pos")]
        public Int32 XPos { get; set; }

        [Column("ypos")]
        [Display(Name = "Y Pos")]
        public Int32 YPos { get; set; }

        public virtual List<Task> Tasks { get; set; }
        public virtual List<Document> Documents { get; set; }
        public virtual List<CalendarEvent> CalendarEvents { get; set; }

        public static void Seed(DataContext context)
        {
            var subjects = new List<Subject>
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

            context.Subjects.AddRange(subjects);
            context.SaveChanges();
        }
    }
}