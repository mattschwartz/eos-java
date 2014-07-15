using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using eos.Models.CalendarEvents;
using eos.Models.Data;
using eos.Models.Documents;
using eos.Models.Subjects;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Task = eos.Models.Tasks.Task;

namespace eos.Models.Users
{
    [Table("eos_users")]
    public class User : IdentityUser, IDataModel
    {
        public User()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;

            if (HttpContext.Current != null && HttpContext.Current.User != null &&
                HttpContext.Current.User.Identity != null &&
                !String.IsNullOrEmpty(HttpContext.Current.User.Identity.GetUserId())) {
                CreatedBy = HttpContext.Current.User.Identity.GetUserId();
                ApiKey = DataUtility.GetId();
            }
        }

        [Column("first_name")]
        public String FirstName { get; set; }

        [Column("last_name")]
        public String LastName { get; set; }

        [Required]
        [Column("created_on")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Column("updated_on")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime UpdatedOn { get; set; }

        [ForeignKey("CreatedByUser")]
        [Column("created_by")]
        [StringLength(36)]
        public String CreatedBy { get; set; }
        public virtual User CreatedByUser { get; set; }

        [Column("api_key")]
        [StringLength(36)]
        public String ApiKey { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Task> Tasks { get; set; }
        public virtual List<CalendarEvent> CalendarEvents { get; set; }
        public virtual List<Document> Documents { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity =
                await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }

        public static void Seed(DataContext context)
        {
            var users = new List<User>
            {
                new User {
                    FirstName = "First Name",
                    LastName = "Last Name",
                    Email = "Email"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}