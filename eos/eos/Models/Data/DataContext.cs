using System.Linq;
using eos.Models.CalendarEvents;
using eos.Models.Documents;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using eos.Models.Subjects;
using eos.Models.Users;
using eos.Models.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eos.Models.Data
{
    public class DataContext : DbContext
    {
#if DEBUG
        private static String _connectionStringName = "Debug";
#else
        private static String _connectionStringName = "Release";
#endif

        public static String ConnectionStringName
        {
            get { return _connectionStringName; }
            set { _connectionStringName = value; }
        }

        public DataContext()
            : base(ConnectionStringName)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Asp.Net Identity Naming

            modelBuilder.Entity<IdentityUser>().ToTable("eos_users");
            modelBuilder.Entity<IdentityUser>().Property(t => t.Id).HasColumnName("id");
            modelBuilder.Entity<IdentityUser>().Property(t => t.Email).HasColumnName("email");
            modelBuilder.Entity<IdentityUser>().Property(t => t.EmailConfirmed).HasColumnName("email_confirmed");
            modelBuilder.Entity<IdentityUser>().Property(t => t.PasswordHash).HasColumnName("password_hash");
            modelBuilder.Entity<IdentityUser>().Property(t => t.SecurityStamp).HasColumnName("security_stamp");
            modelBuilder.Entity<IdentityUser>().Property(t => t.PhoneNumber).HasColumnName("phone_number");
            modelBuilder.Entity<IdentityUser>().Property(t => t.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");
            modelBuilder.Entity<IdentityUser>().Property(t => t.TwoFactorEnabled).HasColumnName("two_factor_enabled");
            modelBuilder.Entity<IdentityUser>().Property(t => t.LockoutEndDateUtc).HasColumnName("lockout_end_date_utc");
            modelBuilder.Entity<IdentityUser>().Property(t => t.LockoutEnabled).HasColumnName("lockout_enabled");
            modelBuilder.Entity<IdentityUser>().Property(t => t.AccessFailedCount).HasColumnName("access_failed_count");
            modelBuilder.Entity<IdentityUser>().Property(t => t.UserName).HasColumnName("username");

            modelBuilder.Entity<User>().ToTable("eos_users");

            modelBuilder.Entity<IdentityRole>().ToTable("eos_roles");
            modelBuilder.Entity<IdentityRole>().Property(t => t.Id).HasColumnName("id");
            modelBuilder.Entity<IdentityRole>().Property(t => t.Name).HasColumnName("name");

            modelBuilder.Entity<IdentityUserRole>().ToTable("eos_users_roles");
            modelBuilder.Entity<IdentityUserRole>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<IdentityUserRole>().Property(t => t.RoleId).HasColumnName("role_id");

            modelBuilder.Entity<IdentityUserLogin>().ToTable("eos_users_logins");
            modelBuilder.Entity<IdentityUserLogin>().Property(t => t.LoginProvider).HasColumnName("login_provider");
            modelBuilder.Entity<IdentityUserLogin>().Property(t => t.ProviderKey).HasColumnName("provider_key");
            modelBuilder.Entity<IdentityUserLogin>().Property(t => t.UserId).HasColumnName("user_id");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("eos_users_claims");
            modelBuilder.Entity<IdentityUserClaim>().Property(t => t.Id).HasColumnName("id");
            modelBuilder.Entity<IdentityUserClaim>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<IdentityUserClaim>().Property(t => t.ClaimType).HasColumnName("claim_type");
            modelBuilder.Entity<IdentityUserClaim>().Property(t => t.ClaimValue).HasColumnName("claim_value");

            #endregion

            modelBuilder.Entity<Task>().HasRequired(t => t.User).WithMany(x => x.Tasks);
            modelBuilder.Entity<Subject>().HasRequired(t => t.User).WithMany(x => x.Subjects);
            modelBuilder.Entity<Document>().HasOptional(t => t.CalendarEvent).WithMany(x => x.Documents);
            modelBuilder.Entity<Document>().HasOptional(t => t.Subject).WithMany(x => x.Documents);
            modelBuilder.Entity<Document>().HasOptional(t => t.Task).WithMany(x => x.Documents);
            modelBuilder.Entity<Document>().HasRequired(t => t.User).WithMany(x => x.Documents);
            modelBuilder.Entity<CalendarEvent>().HasOptional(t => t.Subject).WithMany(x => x.CalendarEvents);
            modelBuilder.Entity<CalendarEvent>().HasOptional(t => t.Task).WithMany(x => x.CalendarEvents);
            modelBuilder.Entity<CalendarEvent>().HasRequired(t => t.User).WithMany(x => x.CalendarEvents);
            
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        //public void Seed()
        //{
        //    User.Seed(this);
        //    Subject.Seed(this);
        //    Task.Seed(this);
        //    Document.Seed(this);
        //    CalendarEvent.Seed(this);
        //}

        #region DbSet

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }

        #endregion

        public override int SaveChanges()
        {
            try {
                var changeSet = ChangeTracker.Entries<BaseModel>();

                if (changeSet != null) {
                    foreach (var entry in changeSet.Where(entry => entry.State != EntityState.Unchanged)) {
                        entry.Entity.UpdatedOn = DateTime.Now;
                    }
                }

                return base.SaveChanges();
            } catch (Exception ex) {
                return -1;
            }
        }

        public static DataContext Create()
        {
            return new DataContext();
        }
    }
}