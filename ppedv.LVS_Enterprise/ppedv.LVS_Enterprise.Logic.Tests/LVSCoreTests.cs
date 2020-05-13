using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.LVS_Enterprise.Model;
using ppedv.LVS_Enterprise.Model.Contracts;
using System;

namespace ppedv.LVS_Enterprise.Logic.Tests
{
    [TestClass]
    public class LVSCoreTests
    {
        [TestMethod]
        public void LVSCore_GetLagerWithMostOfArtikel_artikel_null_throws_ArgumentNullException()
        {
            var core = new LVSCore(null);

            Assert.ThrowsException<ArgumentNullException>(() => core.GetLagerWithMostOfArtikel(null));
        }

        [TestMethod]
        public void LVSCore_GetLagerWithMostOfArtikel_most_in_Lager2()
        {
            var art1 = new Artikel() { Bezeichnung = "A1" };

            var l1 = new Lager() { Standort = "Lager 1" };
            var l2 = new Lager() { Standort = "Lager 2" };

            l1.Lagerungen.Add(new Lagerung() { Artikel = art1, Anzahl = 12 });
            l2.Lagerungen.Add(new Lagerung() { Artikel = art1, Anzahl = 8 });
            l2.Lagerungen.Add(new Lagerung() { Artikel = art1, Anzahl = 6 });

            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Lager>()).Returns(new[] { l1, l2 });
            var core = new LVSCore(mock.Object);

            var result = core.GetLagerWithMostOfArtikel(art1);

            Assert.AreEqual("Lager 2", result.Standort);
        }

    }
}
