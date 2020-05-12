using EfCodeFirst.Model;
using System.Data.Entity;

namespace EfCodeFirst.Data
{
    public class EfContext : DbContext
    {
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Abteilung> Abteilungen { get; set; }
      //  public DbSet<Person> Personen { get; set; }

        public EfContext(string conString) : base(conString)
        { }

        public EfContext() : this("Server=(localdb)\\mssqllocaldb;Database=EfCodeFirst;Trusted_Connection=true")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<EfContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
             
            modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");
            modelBuilder.Entity<Kunde>().ToTable("Kunden");

            //modelBuilder.Entity<Kunde>().Ignore(x => x.Ort);

            modelBuilder.Entity<Kunde>().Property(x => x.KdNummer).HasMaxLength(12).IsRequired().HasColumnName("KUNDENNUMMMER");


            modelBuilder.Entity<Kunde>().Property(x => x.PLZ).IsRequired();
        }
    }
}
