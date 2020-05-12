using System.Collections.Generic;

namespace ppedv.LVS_Enterprise.Model
{
    public class Lager : Entity
    {
        public string Standort { get; set; }

        public virtual ICollection<Lagerung> Lagerungen { get; set; } = new HashSet<Lagerung>();
    }
}
