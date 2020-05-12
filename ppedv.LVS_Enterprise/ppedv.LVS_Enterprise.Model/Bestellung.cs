using System;
using System.Collections.Generic;

namespace ppedv.LVS_Enterprise.Model
{
    public class Bestellung : Entity
    {
        public DateTime Datum { get; set; }
        public string Auftraggeber { get; set; }
        public ICollection<BestellPosition> BestellPositionen { get; set; } = new HashSet<BestellPosition>();
    }
}
