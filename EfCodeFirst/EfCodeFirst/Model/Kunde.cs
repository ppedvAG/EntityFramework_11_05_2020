using System;

namespace EfCodeFirst.Model
{
    public class Kunde : Person
    {
        public string KdNummer { get; set; }
        public Mitarbeiter Mitarbeiter { get; set; }

        public string Addresse { get; set; }
        public string Ort { get; set; }
        public int PLZ { get; set; } = 89;

        public DateTime MitgliedSeit { get; set; }
    }

}
