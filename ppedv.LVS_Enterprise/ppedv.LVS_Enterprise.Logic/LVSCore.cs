using ppedv.LVS_Enterprise.Model.Contracts;

namespace ppedv.LVS_Enterprise.Logic
{
    public class LVSCore
    {
        public IRepository Repository { get; private set; }

        public LVSCore(IRepository repo)  //DI in here
        {
            Repository = repo;
        }

        public LVSCore() : this(new Data.EF.EfRepository())
        { }
    }
}
