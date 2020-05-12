﻿using System.Collections.Generic;

namespace EfCodeFirst.Model
{
    public class Abteilung
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public ICollection<Mitarbeiter> Mitarbeiter { get; set; } = new HashSet<Mitarbeiter>();
    }

}
