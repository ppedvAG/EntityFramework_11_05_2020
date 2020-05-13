using ppedv.LVS_Enterprise.Model;
using ppedv.LVS_Enterprise.Model.Contracts;
using System;
using System.Linq;

namespace ppedv.LVS_Enterprise.Logic
{
    public class LVSCore
    {
        public IRepository Repository { get; private set; }

        public LVSCore(IRepository repo)  //DI in here
        {
            Repository = repo;
        }

        public Lager GetLagerWithMostOfArtikel(Artikel artikel)
        {   
            if (artikel == null)
                throw new ArgumentNullException();

            return Repository.GetAll<Lager>()
                             .OrderByDescending(x => x.Lagerungen.Where(y => y.Artikel.Id == artikel.Id).Sum(y => y.Anzahl))
                             .FirstOrDefault();
        }

        public LVSCore() : this(new Data.EF.EfRepository())
        { }
    }
}
