using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eos.Models.CalendarEvents;
using eos.Models.Data;
using eos.Models.Documents;
using eos.Models.Subjects;
using eos.Models.Tasks;

namespace eos.Models.Users
{
    [Table("eos_users")]
    public class User : BaseModel
    {
        [Column("first_name")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Column("last_name")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Column("username")]
        [Display(Name = "Username")]
        public String Username { get; set; }

        [Column("email")]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Column("password")]
        [Display(Name = "Password")]
        public String Password { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Task> Tasks { get; set; }

        [Display(Name = "Calendar Events")]
        public virtual List<CalendarEvent> CalendarEvents { get; set; }

        public virtual List<Document> Documents { get; set; }

        public static void Seed(DataContext context)
        {
            var users = new List<User>
            {
                new User {
                    FirstName = "First Name",
                    LastName = "Last Name",
                    Email = "Email",
                    Password = "Password",
                    Username = "Username"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}