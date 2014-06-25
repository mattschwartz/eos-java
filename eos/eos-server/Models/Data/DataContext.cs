using Ionic.Zip;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Reflection;
using eos.Models.Subjects;
using eos.Models.Users;
using eos.Models.Tasks;

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
            //modelBuilder.Entity<Task>().HasOptional(t => t.DeletedBy);
            //modelBuilder.Entity<Task>().HasRequired(t => t.CreatedBy);
            //modelBuilder.Entity<Subject>().HasOptional(t => t.DeletedBy);
            //modelBuilder.Entity<Subject>().HasRequired(t => t.CreatedBy);
            //modelBuilder.Entity<User>().HasRequired(t => t.CreatedBy).WithOptional(x => x.);
            //modelBuilder.Entity<User>().HasOptional(t => t.DeletedBy);
            modelBuilder.Entity<Task>().HasRequired(t => t.User).WithMany(x => x.Tasks);
            modelBuilder.Entity<Subject>().HasOptional(t => t.User).WithMany(x => x.Subjects);
            //modelBuilder.Entity<User>().HasOptional(t => t.CreatedBy).WithOptionalDependent();
            
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
        }

        public void Unseed()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "eos.Sql.Initial.sql";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream)) {
                var initialSql = reader.ReadToEnd();

                var objectContext = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this).ObjectContext;
                objectContext.ExecuteStoreCommand(initialSql);
                objectContext.SaveChanges();
            }
        }

        #region DbSet

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        #endregion
    }
}