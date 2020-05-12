using System;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.LVS_Enterprise.Model;

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

        [TestMethod]
        public void EfContext_can_CRUD_Artikel()
        {
            var art = new Artikel()
            {
                Bezeichnung = $"Test_{Guid.NewGuid()}",
                Farbe = "blau",
                Gewicht = 12.7,
                Preis = 89.44m,
                Form = Form.Kugel
            };

            var newBez = $"TestNew_{Guid.NewGuid()}";

            //CREATE
            using (var con = new EfContext())
            {
                con.Artikel.Add(art);
                con.SaveChanges();
            }//con.Dispose(); 

            //check READ
            using (var con = new EfContext())
            {
                var loaded = con.Artikel.Find(art.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(art.Bezeichnung, loaded.Bezeichnung);

                //UPDATE
                loaded.Bezeichnung = newBez;
                con.SaveChanges();
            }

            //check UPDATE
            using (var con = new EfContext())
            {
                var loaded = con.Artikel.Find(art.Id);
                Assert.AreEqual(newBez, loaded.Bezeichnung);

                //DELETE
                con.Artikel.Remove(loaded);
                con.SaveChanges();
            }
            //check DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Artikel.Find(art.Id);
                Assert.IsNull(loaded);
            }
        }

        [TestMethod]
        public void EfContext_Artikel_AutoFix()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());

            var art = fix.Build<Artikel>().Create();
            using (var con = new EfContext())
            {
                con.Artikel.Add(art);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Artikel.Find(art.Id);

                loaded.Should().NotBeNull();
                loaded.Should().BeEquivalentTo(art, x => x.IgnoringCyclicReferences());
            }
        }

    }
}
