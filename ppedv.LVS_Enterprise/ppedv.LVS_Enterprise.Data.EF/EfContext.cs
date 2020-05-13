using ppedv.LVS_Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.LVS_Enterprise.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Lager> Lager { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<BestellPosition> BestellPositionen { get; set; }
        public DbSet<Lagerung> Lagerungen { get; set; }

        public EfContext(string conString) : base(conString)
        { }

        public EfContext() : this("Server=(localdb)\\mssqllocaldb;Database=LVS_Enterprise_dev;Trusted_Connection=true")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //alle DateTime werden datetime2 in der DB
            //modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));

            //nur created und modified werden datetime2 in der DB
            modelBuilder.Properties<DateTime>().Where(x => x.Name == nameof(Entity.Created)
                                                        || x.Name == nameof(Entity.Modified))
                                               .Configure(x => x.HasColumnType("datetime2"));
        }
    }
}
