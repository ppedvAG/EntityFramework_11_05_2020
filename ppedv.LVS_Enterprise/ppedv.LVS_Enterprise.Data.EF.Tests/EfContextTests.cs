using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.LVS_Enterprise.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_database()
        {
            var con = new EfContext();

            if (con.Database.Exists())
                con.Database.Delete();

            Assert.IsFalse(con.Database.Exists());
            con.Database.CreateIfNotExists();
            Assert.IsTrue(con.Database.Exists());
        }
    }
}
