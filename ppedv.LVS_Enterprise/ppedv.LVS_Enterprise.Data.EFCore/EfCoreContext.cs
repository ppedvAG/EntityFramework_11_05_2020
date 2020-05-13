using Microsoft.EntityFrameworkCore;
using ppedv.LVS_Enterprise.Model;
using System;

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

    }
}
