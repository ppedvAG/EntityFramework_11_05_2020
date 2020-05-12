namespace ppedv.LVS_Enterprise.Model
{
    public class BestellPosition : Entity
    {
        public virtual Bestellung Bestellung { get; set; }
        public virtual Artikel Artikel { get; set; }
        public int Menge { get; set; }
    }
}
