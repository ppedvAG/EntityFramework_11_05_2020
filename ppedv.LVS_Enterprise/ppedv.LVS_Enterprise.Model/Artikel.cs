using System.Collections.Generic;

namespace ppedv.LVS_Enterprise.Model
{
    public class Artikel : Entity
    {
        public string Bezeichnung { get; set; }
        public string Farbe { get; set; }
        public double Gewicht { get; set; }
        public decimal Preis { get; set; }
        public Form Form { get; set; }
        public ICollection<Lagerung> Lagerung { get; set; } = new HashSet<Lagerung>();
    }

    public enum Form
    {
        Quader,
        Zylinder,
        Pyramide,
        Kugel
    }
}
