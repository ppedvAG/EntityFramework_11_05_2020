namespace ppedv.LVS_Enterprise.Model
{
    public class BestellPosition : Entity
    {
        public Bestellung Bestellung { get; set; }
        public Artikel Artikel { get; set; }
        public int Menge { get; set; }
    }
}
