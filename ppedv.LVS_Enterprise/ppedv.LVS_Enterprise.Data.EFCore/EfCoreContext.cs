using Microsoft.EntityFrameworkCore;
using ppedv.LVS_Enterprise.Model;
using System;
using System.Linq;

namespace ppedv.LVS_Enterprise.Data.EFCore
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Lager> Lager { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<BestellPosition> BestellPositionen { get; set; }
        public DbSet<Lagerung> Lagerungen { get; set; }


        public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
        { }

        public EfCoreContext(string conString) : this(new DbContextOptionsBuilder<EfCoreContext>().UseSqlServer(conString).Options)
        { }

        public EfCoreContext() : this("Server=(localdb)\\mssqllocaldb;Database=LVS_Enterprise_dev_EFCORE;Trusted_Connection=true")
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //   modelBuilder.Entity<Artikel>().Property(x => x.Bezeichnung).HasDefaultValue("lala");

            //modelBuilder.Entity<Artikel>().Property(x => x.Modified).IsConcurrencyToken();
            modelBuilder.Entity<Artikel>().Property(x => x.Modified).IsConcurrencyToken();

        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
            {
                var dt = DateTime.Now;
                ((Entity)item.Entity).Created = dt;
                ((Entity)item.Entity).Modified = dt;
                ((Entity)item.Entity).LastUser = Environment.UserName;
            }

            foreach (var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Modified))
            {
                var dt = DateTime.Now;
                ((Entity)item.Entity).Modified = dt;
                ((Entity)item.Entity).LastUser = Environment.UserName;
            }

            return base.SaveChanges();
        }

    }
}
