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
            modelBuilder.Entity<Task>().HasRequired(t => t.user);
            modelBuilder.Entity<Task>().HasOptional(t => t.deletedBy);
            modelBuilder.Entity<Subject>().HasRequired(t => t.user);
            modelBuilder.Entity<Subject>().HasOptional(t => t.deletedBy);
            //modelBuilder.Entity<BinSizing>().HasRequired(t => t.Sizing).WithMany();
            //modelBuilder.Entity<Customer>().HasMany(x => x.Locations).WithMany(x => x.Customers).Map(x => { x.ToTable("aztec_customer_locations"); x.MapLeftKey("customer_id"); x.MapRightKey("location_id"); });
            //modelBuilder.Entity<EmbellishmentPricingCharge>().HasOptional(i => i.AttributeType).WithMany(x => x.PricingCharges);
            //modelBuilder.Entity<EmbellishmentPricingCharge>().HasOptional(i => i.ConditionalAttributeType).WithMany(x => x.ConditionalPricingCharges);
            //modelBuilder.Entity<EmbellishmentType>().HasMany(x => x.AttributeTypes).WithMany(x => x.Types).Map(x => { x.ToTable("aztec_embellishment_type_attributes"); x.MapLeftKey("embellishmenttypeid"); x.MapRightKey("embellishmentattributetypeid"); });
            //modelBuilder.Entity<ImageTemplate>().HasOptional(t => t.SelectedVersion).WithMany();
            //modelBuilder.Entity<Job>().HasOptional(t => t.Bin).WithOptionalPrincipal();
            //modelBuilder.Entity<Job>().HasOptional(t => t.OutsourcedPurchaseOrder).WithOptionalPrincipal();
            //modelBuilder.Entity<Job>().HasRequired(t => t.Employee).WithMany();
            //modelBuilder.Entity<Job>().HasRequired(t => t.SalesLocation).WithMany(t => t.SalesJobs);
            //modelBuilder.Entity<Job>().HasRequired(t => t.ArtLocation).WithMany(t => t.ArtJobs);
            //modelBuilder.Entity<Job>().HasRequired(t => t.ProductionLocation).WithMany(t => t.ProductionJobs);
            //modelBuilder.Entity<JobPricingCharge>().HasRequired(t => t.JobAttributeType).WithMany(x => x.JobPricingCharges);
            //modelBuilder.Entity<JobPricingCharge>().HasOptional(t => t.ConditionalJobAttributeType).WithMany(x => x.ConditionalJobPricingCharges);
            //modelBuilder.Entity<LineItem>().HasRequired(t => t.Job).WithMany();
            //modelBuilder.Entity<Location>().HasOptional(t => t.SalesLocation).WithMany();
            //modelBuilder.Entity<Location>().HasOptional(t => t.ArtLocation).WithMany();
            //modelBuilder.Entity<Location>().HasOptional(t => t.ProductionLocation).WithMany();
            //modelBuilder.Entity<Note>().HasOptional(t => t.Sizings).WithOptionalPrincipal();
            //modelBuilder.Entity<OutsourcedJob>().HasRequired(t => t.Job).WithMany();
            //modelBuilder.Entity<Payment>().HasOptional(t => t.Prepayment).WithOptionalPrincipal();
            //modelBuilder.Entity<Reminder>().HasOptional(t => t.JobNote).WithOptionalPrincipal();
            //modelBuilder.Entity<Reminder>().HasOptional(t => t.Note).WithOptionalPrincipal();
            //modelBuilder.Entity<SizedImage>().HasRequired(t => t.ArtMessage).WithRequiredPrincipal();
            //modelBuilder.Entity<Sizing>().HasOptional(t => t.Note).WithMany(x => x.Sizings);
            //modelBuilder.Entity<Tag>().HasRequired(t => t.ValueImageTag).WithRequiredPrincipal();
            //modelBuilder.Entity<ValueImageTag>().HasOptional(t => t.ValueImage).WithMany();

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
            //User.Seed(this);
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