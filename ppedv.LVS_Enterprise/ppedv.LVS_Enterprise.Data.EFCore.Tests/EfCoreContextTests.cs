using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.LVS_Enterprise.Data.EFCore.Tests
{
    [TestClass]
    public class EfCoreContextTests
    {
        [TestMethod]
        public void EfCoreContext_Can_create_db()
        {
            var con = new EfCoreContext();

            
            con.Database.EnsureDeleted();
            Assert.IsFalse((con.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists());

            con.Database.EnsureCreated();
            Assert.IsTrue((con.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists());
        }
    }
}
