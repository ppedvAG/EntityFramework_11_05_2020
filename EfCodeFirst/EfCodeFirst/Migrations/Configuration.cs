﻿namespace EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EfCodeFirst.Data.EfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = !true;
            //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "EfCodeFirst.Data.EfContext";
        }

        protected override void Seed(EfCodeFirst.Data.EfContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
