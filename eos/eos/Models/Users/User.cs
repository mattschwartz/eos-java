using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eos.Models.Data;
using eos.Models.Subjects;
using eos.Models.Tasks;

namespace eos.Models.Users
{
    [Table("eos_users")]
    public class User : BaseModel
    {
        public User() 
            : base()
        {

        }

        [Column("first_name")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Column("last_name")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Column("email")]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Column("password")]
        [Display(Name = "Password")]
        public String Password { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Task> Tasks { get; set; }

        public static void Seed(DataContext context)
        {
            var users = new List<User>
            {
                new User {
                    FirstName = "First Name",
                    LastName = "Last Name",
                    Email = "Email",
                    Password = "password"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}