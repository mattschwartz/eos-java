using System.Diagnostics;
using eos.Models.Documents;
using eos.Properties;
using Ionic.Zip;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Reflection;
using eos.Models.Subjects;
using eos.Models.Users;
using eos.Models.Tasks;
using eos.Models.Events;

namespace eos.Models.Data
{
    public class DataContext : DbContext
    {
#if RELEASE
        public DataContext()
            : base("Release")
        {
        }
#else
        public DataContext()
            : base("Debug")
        {
        }
#endif

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasRequired(t => t.User).WithMany(x => x.Tasks);
            modelBuilder.Entity<Subject>().HasRequired(t => t.User).WithMany(x => x.Subjects);
            modelBuilder.Entity<Document>().HasOptional(t => t.Event).WithMany(x => x.Documents);
            modelBuilder.Entity<Document>().HasOptional(t => t.Subject).WithMany(x => x.Documents);
            modelBuilder.Entity<Document>().HasOptional(t => t.Task).WithMany(x => x.Documents);
            modelBuilder.Entity<Document>().HasRequired(t => t.User).WithMany(x => x.Documents);
            modelBuilder.Entity<CalendarEvent>().HasOptional(t => t.Subject).WithMany(x => x.CalendarEvents);
            modelBuilder.Entity<CalendarEvent>().HasOptional(t => t.Task).WithMany(x => x.CalendarEvents);
            modelBuilder.Entity<CalendarEvent>().HasRequired(t => t.User).WithMany(x => x.CalendarEvents);
            
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public static void Setup()
        {
            var zipPath = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "eos-data.zip");
            var dataPath = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "eos.mdf");

            if (!File.Exists(dataPath)) {
                using (var zip = ZipFile.Read(zipPath)) {
                    zip.ExtractAll(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), ExtractExistingFileAction.DoNotOverwrite);
                }
            }

            using (var context = new DataContext()) {
                context.Unseed();
                context.Seed();
            }
        }

        public void Seed()
        {
            User.Seed(this);
            Subject.Seed(this);
            Task.Seed(this);
            Document.Seed(this);
            CalendarEvent.Seed(this);
        }

        public void Unseed()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(Settings.Default.DatabaseSqlScript))
            {
                Debug.Assert(stream != null, "stream != null");
                using (var reader = new StreamReader(stream)) {
                    var initialSql = reader.ReadToEnd();

                    var objectContext = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this).ObjectContext;
                    objectContext.ExecuteStoreCommand(initialSql);
                    objectContext.SaveChanges();
                }
            }
        }

        #region DbSet

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<CalendarEvent> Events { get; set; }

        #endregion
    }
}